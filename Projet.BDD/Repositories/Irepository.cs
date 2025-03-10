namespace Projet.BDD.Repositories
{
    public interface Irepository<T>
    {
        Task<List<T>> getAll();



    }
}