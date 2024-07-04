using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class DevicesServices : IDevicesServices
    {
        private readonly AppDbContext _context;

        public DevicesServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Devices
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name });
        }
    }
}
