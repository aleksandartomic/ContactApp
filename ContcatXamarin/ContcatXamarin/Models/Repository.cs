using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using ContcatXamarin.Services;

namespace ContcatXamarin.Models
{
    public class Repository : DbContext, IRepository<User>
    {
        public DbSet<User> Users { get; set; }
        string _dbPath;
        public Repository()
        {

        }
        public Repository(string dbPath) : base()
        {
            _dbPath = dbPath;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired();
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            var allUsers = await Users.ToListAsync();
            return allUsers;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            Users.Update(user);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userToRemove = Users.FirstOrDefault(x => x.Id == id);
            if (userToRemove != null)
            {
                Users.Remove(userToRemove);
                await SaveChangesAsync();
            }

            return true;
        }
    }
}
