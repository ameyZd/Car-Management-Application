using System.Threading.Tasks;
using ViewModels;

namespace CarManagement.BAL.Agents.Interfaces
{
    public interface ILoginManager
    {

        /// <summary>
        /// Verification of valid users
        /// </summary>
        /// <param name="user">user details</param>
        /// <returns>true if valid user false if invalid user</returns>
        Task<bool> Verification(UserViewModel user);
    }
}
