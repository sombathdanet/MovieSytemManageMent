using MovieSytemManageMent.Data;
using MovieSytemManageMent.Model;

namespace MovieSytemManageMent.Repositories
{
    // ── Interface ────────────────────────────────────────────────────────
    public interface IActorRepository
    {
        List<Actor> GetAll();
        void Add(Actor actor);
        void Delete(int id);
    }

    // ── Implementation ───────────────────────────────────────────────────
    public class ActorRepository : IActorRepository
    {
        private readonly MovieDataStore _store = MovieDataStore.Instance;

        public List<Actor> GetAll() => _store.Actors;
        public void Add(Actor actor) => _store.AddActor(actor);
        public void Delete(int id) => _store.DeleteActor(id);
    }
}