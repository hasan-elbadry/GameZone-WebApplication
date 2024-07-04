using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModel;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGamesServices _GamesServices;



        public GamesController(ICategoriesServices categoriesServices,IDevicesServices devicesServices, IGamesServices gamesServices)
        {
            _categoriesServices = categoriesServices;
            _devicesServices = devicesServices;
            _GamesServices = gamesServices;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _GamesServices.GetAll();
            return View(games);
        }

        [HttpGet]
        public  IActionResult Details(int id)
        {
            var game = _GamesServices.GetById(id);
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateGameFormModelView
            {
                Categories = _categoriesServices.GetSelectList(),

                Devices = _devicesServices.GetSelectList()
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateGameFormModelView model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectList();

                model.Devices = _devicesServices.GetSelectList();
                return View(model);
            }
            _GamesServices.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _GamesServices.GetById(id);

            EditGameFormViewModel editgame = new()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Categories = _categoriesServices.GetSelectList(),
                Devices = _devicesServices.GetSelectList(),
                CategoryId = id,
                SelectedDevices = game.gameDevices.Select(d => d.DeviceId).ToList(),
                CurrentCover = game.Cover
            };

            return View(editgame);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async  Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectList();

                model.Devices = _devicesServices.GetSelectList();
                return View(model);
            }
            await _GamesServices.Update(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _GamesServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
