using Microsoft.EntityFrameworkCore;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
          : base(options)
        {
        }

        public DbSet<ToDoItemModel> ToDoItems { get; set; }
    }
}
