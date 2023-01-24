using System.Xml.Linq;

namespace SpaceJetMedia.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _users;

        public MockUserRepository()
        {
            XDocument xDoc = XDocument.Load("UsersTest.xml");
            _users = xDoc.Descendants("User").Select(user => new User
            {
                Id = Convert.ToInt32(user.Attribute("id").Value),
                ClientId = Convert.ToInt32(user.Element("ClientId").Value),
                FirstName = user.Element("FirstName").Value,
                LastName = user.Element("LastName").Value,
                Email = user.Element("Email").Value,
                IsBusinessContact = Convert.ToBoolean(user.Element("IsBusinessContact").Value),
                IsAccountingContact = Convert.ToBoolean(user.Element("IsAccountingContact").Value),
                HasApiAccess = Convert.ToBoolean(user.Element("HasApiAccess").Value)
            }).ToList();
        }

        public IEnumerable<User> AllUsers => _users;

        public IEnumerable<User> SearchUsers(string searchQuery)
        {
            return AllUsers.Where(p => p.FirstName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) || p.LastName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) || p.Email.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
        }
    }
}
