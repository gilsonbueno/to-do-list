using WebApplication.Model;

namespace WebApplication.Repository
{
    public class ToDoRepository : BaseRepository<ToDoItemModel>
    {
        public ToDoRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
