using DataRacingV1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using YourNamespace.Models;

namespace DataRacingV1.Services
{
    public class UploadFileService
    {
        private readonly string _uploadFolder;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UploadFileService> _logger;

        public UploadFileService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, ILogger<UploadFileService> logger)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;

            _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public async Task<UploadedFile> UploadFileAsync(UploadedFileInfo uploadedFileInfo)
        {
            var fileId = Guid.NewGuid();
            var newFileName = $"{fileId}_{uploadedFileInfo.FileName}";
            var filePath = Path.Combine(_uploadFolder, newFileName);

            _logger.LogInformation($"Uploading file: {newFileName}, Size: {uploadedFileInfo.FileContent.Length}");

            try
            {
                await File.WriteAllBytesAsync(filePath, uploadedFileInfo.FileContent);

                _logger.LogInformation($"File uploaded: {filePath}, Size: {new FileInfo(filePath).Length}");

                var uploadedFile = new UploadedFile
                {
                    Id = fileId,
                    UserId = await GetCurrentUserIdAsync(),
                    Name = uploadedFileInfo.FileName,
                    Path = filePath,
                    Comment = $"Equipo: {uploadedFileInfo.Equipo}, Archivo: {uploadedFileInfo.Archivo}",
                    CreatedAt = DateTime.UtcNow
                };

                return uploadedFile;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error uploading file: {newFileName}");
                throw;
            }
        }

        private async Task<string> GetCurrentUserIdAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user?.Id;
        }
    }
}