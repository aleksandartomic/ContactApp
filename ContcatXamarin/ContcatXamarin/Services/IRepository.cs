using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContcatXamarin.Services
{
    public interface IRepository<T>
    {
        Task<bool> AddUserAsync(T user);
        Task<bool> UpdateUserAsync(T user);
        Task<bool> DeleteUserAsync(int id);
        Task<T> GetUserAsync(int id);
        Task<IEnumerable<T>> GetUsersAsync(bool forceRefresh = false);
    }
}
