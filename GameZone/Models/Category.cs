
namespace GameZone.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        public List<Game> games { get; set; }
    }
}
