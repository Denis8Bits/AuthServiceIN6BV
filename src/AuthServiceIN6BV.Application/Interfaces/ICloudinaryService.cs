namespace AuthServiceIN6BV.Application.Interfaces;

public interface ICloudinaryService
{
    Task<String> UploadImageAsync(IFileData imageFile, string FileName);
    Task<bool> DeleteImageAsync(string publicId);
    string GetDefaultAvatarUrl();
    string GetFullImageUrl(string imagePath);
}