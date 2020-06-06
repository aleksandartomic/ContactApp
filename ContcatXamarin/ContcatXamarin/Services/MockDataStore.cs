using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContcatXamarin.Models;

namespace ContcatXamarin.Services
{
    public class MockDataStore : IRepository<User>
    {
        readonly List<User> users;

        public MockDataStore()
        {
            users = new List<User>()
            {
                new User { Id = 1, Name = "AAA", LastName = "BBB", Address = "CCC", Number = "018" }
            };
        }

        public async Task<bool> AddUserAsync(User user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var oldUser = users.Where((User arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(oldUser);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var oldUser = users.Where((User arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldUser);

            return await Task.FromResult(true);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }
}