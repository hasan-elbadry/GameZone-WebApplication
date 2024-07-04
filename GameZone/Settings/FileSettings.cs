using static System.Net.Mime.MediaTypeNames;

namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string imagesPath = "/Assets/Images/Games";
        public const string allowedExtentions = ".jpg,.jpeg,.png";
        public const int maxFileSizeInMB= 4;
        public const int maxFileSizeInBytes = maxFileSizeInMB * 1024 * 1024;



    }
}
