using System.Collections.Generic;
using WebApplication.DataContractObject;

namespace WebApplication.Business.Interface
{
    public interface IToDoBusiness
    {
        List<ToDoItemDto> GetAll();
        ToDoItemDto GetById(int id);
        ToDoItemDto Create(ToDoItemDto todoItem);
        ToDoItemDto Update(ToDoItemDto todoItem);
        ToDoItemDto UpdateStatus(int id);
        void Delete(int id);
    }
}
