using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly AppDbContext _context;

        public CategoriesServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        }
    }
}
