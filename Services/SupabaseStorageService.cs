using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MovieDataBase.Services
{
    public class SupabaseStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _supabaseUrl;
        private const string BucketName = "movie-images";

        public SupabaseStorageService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _supabaseUrl = httpClient.BaseAddress?.ToString().TrimEnd('/')
                ?? throw new ArgumentNullException("Supabase:Url não configurado via HttpClient.BaseAddress");
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folder = "movies")
        {
            var fileName = $"{folder}/{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            var url = $"{_supabaseUrl}/storage/v1/object/{BucketName}/{fileName}";
            
            using var content = new ByteArrayContent(fileBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            
            var response = await _httpClient.PostAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao fazer upload: {error}");
            }

            return GetPublicUrl(fileName);
        }

        public string GetPublicUrl(string filePath)
        {
            return $"{_supabaseUrl}/storage/v1/object/public/{BucketName}/{filePath}";
        }

        public async Task DeleteImageAsync(string filePath)
        {
            var url = $"{_supabaseUrl}/storage/v1/object/{BucketName}/{filePath}";
            await _httpClient.DeleteAsync(url);
        }

        // Gera uma URL assinada (temporária) para um ficheiro privado.
        public async Task<string> GetSignedUrlAsync(string filePath, int expiresInSeconds = 60)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));

            var requestPath = $"storage/v1/object/sign/{BucketName}/{filePath}";
            var payload = JsonSerializer.Serialize(new { expiresIn = expiresInSeconds });
            using var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestPath, content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao obter signed URL: {error}");
            }

            await using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            if (doc.RootElement.TryGetProperty("signedURL", out var v) && v.ValueKind == JsonValueKind.String)
                return v.GetString()!;
            if (doc.RootElement.TryGetProperty("signedUrl", out v) && v.ValueKind == JsonValueKind.String)
                return v.GetString()!;
            if (doc.RootElement.TryGetProperty("signed_url", out v) && v.ValueKind == JsonValueKind.String)
                return v.GetString()!;

            throw new Exception("Resposta inválida: signed URL não encontrada");
        }

    }
}