using GameZone.Atributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace GameZone.ViewModel
{
    public class CreateGameFormModelView : GameFormViewModel
    {
        [AllowedExtentions(FileSettings.allowedExtentions), MaxFileSize(FileSettings.maxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
