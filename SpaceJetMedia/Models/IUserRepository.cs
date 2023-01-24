namespace SpaceJetMedia.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> AllUsers { get; }
        IEnumerable<User> SearchUsers(string searchQuery);
    }
}
