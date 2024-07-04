namespace GameZone.Atributes
{
    public class MaxFileSize: ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSize(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var File = value as IFormFile;
            if (File is not null)
            {
                if (File.Length > _maxFileSize)
                {
                    return new ValidationResult($"Max allowed size is {_maxFileSize} Bytes.");
                }
                return ValidationResult.Success;
            }   
            return new ValidationResult("file is null");
        }
    }
}
