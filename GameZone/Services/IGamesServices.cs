namespace GameZone.Services
{
    public interface IGamesServices
    {

        Task<IEnumerable<Game>> GetAll();
        Game? GetById(int id);
        void Create(CreateGameFormModelView game);
        Task<Game?> Update(EditGameFormViewModel game);
        bool Delete(int id);
    }
}
