using GameZone.Atributes;

namespace GameZone.ViewModel;

public class EditGameFormViewModel : GameFormViewModel
{
    public int Id { get; set; }

    public string? CurrentCover { get; set; }

    [AllowedExtentions(FileSettings.allowedExtentions),
        MaxFileSize(FileSettings.maxFileSizeInBytes)]
    public IFormFile? Cover { get; set; } = default!;
}