
namespace GameZone.Models
{
    public class Device
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Icon { get; set; } = string.Empty;

        public List<GameDevice> gameDevices { get; set; }
    }
}
