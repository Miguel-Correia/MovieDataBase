using Minio;
using Minio.DataModel.Args;

namespace MovieDataBase.Services
{
   public interface IStorageService
    {
        Task<string> UploadImageAsync(IFormFile file, string bucketName = "movie-images");
        Task<bool> DeleteImageAsync(string imageUrl, string bucketName = "movie-images");
        string GetFullUrl(string relativePath); // NOVO
    }   

    public class MinioStorageService : IStorageService
    {
        private readonly IMinioClient _minioClient;
        private readonly string _endpoint;  

        public MinioStorageService(IMinioClient minioClient, IConfiguration configuration)
        {
            _minioClient = minioClient;
            _endpoint = configuration["MinIO:Endpoint"] ?? "localhost:9002";
        }   

        public async Task<string> UploadImageAsync(IFormFile file, string bucketName = "movie-images")
        {
            var bucketExists = await _minioClient.BucketExistsAsync(
                new BucketExistsArgs().WithBucket(bucketName)); 

            if (!bucketExists)
            {
                await _minioClient.MakeBucketAsync(
                    new MakeBucketArgs().WithBucket(bucketName));
                
                var policy = @$"{{
                    ""Version"": ""2012-10-17"",
                    ""Statement"": [
                        {{
                            ""Effect"": ""Allow"",
                            ""Principal"": {{""AWS"": [""*""]}},
                            ""Action"": [""s3:GetObject""],
                            ""Resource"": [""arn:aws:s3:::{bucketName}/*""]
                        }}
                    ]
                }}";
                
                await _minioClient.SetPolicyAsync(
                    new SetPolicyArgs()
                        .WithBucket(bucketName)
                        .WithPolicy(policy));
            }   

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";   

            using (var stream = file.OpenReadStream())
            {
                await _minioClient.PutObjectAsync(
                    new PutObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(fileName)
                        .WithStreamData(stream)
                        .WithObjectSize(file.Length)
                        .WithContentType(file.ContentType));
            }   

            // Guardar apenas o caminho relativo
            return $"{bucketName}/{fileName}";
        }   

        public async Task<bool> DeleteImageAsync(string relativePath, string bucketName = "movie-images")
        {
            try
            {
                // Extrair bucket e filename do caminho relativo
                var parts = relativePath.Split('/', 2);
                if (parts.Length == 2)
                {
                    bucketName = parts[0];
                    var fileName = parts[1];
                    
                    await _minioClient.RemoveObjectAsync(
                        new RemoveObjectArgs()
                            .WithBucket(bucketName)
                            .WithObject(fileName));
                }   

                return true;
            }
            catch
            {
                return false;
            }
        }   

        public string GetFullUrl(string relativePath)
        {
            // Retorna URL completo: http://localhost:9002/movie-images/abc-123.jpg
            return $"http://{_endpoint}/{relativePath}";
        }
    }   

    public class SupabaseStorageService : IStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _supabaseUrl;
        private readonly string _supabaseKey;   

        public SupabaseStorageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _supabaseUrl = configuration["Supabase:Url"];
            _supabaseKey = configuration["Supabase:Key"];
            
            _httpClient.DefaultRequestHeaders.Add("apikey", _supabaseKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_supabaseKey}");
        }   

        public async Task<string> UploadImageAsync(IFormFile file, string bucketName = "movie-images")
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            
            using var fileStream = file.OpenReadStream();
            using var streamContent = new StreamContent(fileStream);
            
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType); 

            var response = await _httpClient.PostAsync(
                $"{_supabaseUrl}/storage/v1/object/{bucketName}/{fileName}", 
                streamContent); 

            response.EnsureSuccessStatusCode(); 

            // Guardar apenas o caminho relativo
            return $"{bucketName}/{fileName}";
        }   

        public async Task<bool> DeleteImageAsync(string relativePath, string bucketName = "movie-images")
        {
            try
            {
                var response = await _httpClient.DeleteAsync(
                    $"{_supabaseUrl}/storage/v1/object/{relativePath}");    

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }   

        public string GetFullUrl(string relativePath)
        {
            // Retorna URL completo do Supabase
            return $"{_supabaseUrl}/storage/v1/object/public/{relativePath}";
        }
    }
}