using GameZone.Settings;

namespace GameZone.Atributes
{
    public class AllowedExtentions : ValidationAttribute
    {
        private readonly string _allowedExtentions;
        public AllowedExtentions(string allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var File = value as IFormFile;
            if(File is not null)
            {
                var extention = Path.GetExtension(File.FileName);

                var allowedExtentions = _allowedExtentions
                    .Split(',')
                    .Contains(extention,StringComparer.OrdinalIgnoreCase);
                if (!allowedExtentions)
                {
                    return new ValidationResult($"Only {_allowedExtentions} are allowed");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("file is null");
        }
    }
}
