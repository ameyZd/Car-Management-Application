using System.Collections.Generic;
using System.Linq;

namespace CarManagement.DAL.Services.Home
{
    public class UserAuthenticationService
    {
        private static CarManagementEntities db = null;

        static UserAuthenticationService()
        {
            db = new CarManagementEntities();
        }

        /// <summary>
        /// All the users who can login
        /// </summary>
        /// <returns>List of users who can login</returns>
        public List<User> PutValue()
        {
            return db.Users.AsNoTracking().ToList();
        }

        /// <summary>
        /// Verification of user trying to login
        /// </summary>
        /// <param name="user">Username and password</param>
        /// <returns>Verified user</returns>
        public bool Verify(User user)
        {
            var persons = PutValue();
            var correctPerson = persons.FirstOrDefault(x => x.UserName.Equals(user.UserName));
            var correctPassword = correctPerson != null && correctPerson.Password.Equals(user.Password);

            return correctPassword;
        }
    }
}
