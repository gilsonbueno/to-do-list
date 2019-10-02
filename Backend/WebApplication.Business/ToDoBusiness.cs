using Mapster;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Business.Interface;
using WebApplication.DataContractObject;
using WebApplication.Model;
using WebApplication.Repository;

namespace WebApplication.Business
{
    public class ToDoBusiness : IToDoBusiness
    {
        private readonly ToDoRepository _toDoRepository;

        public ToDoBusiness(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public ToDoItemDto Create(ToDoItemDto todoItem)
        {
            var todoModel = todoItem.Adapt<ToDoItemModel>();
            var result = _toDoRepository.Create(todoModel).Adapt<ToDoItemDto>();
            return result;
        }

        public void Delete(int id)
        {
            _toDoRepository.Delete(id);
        }

        public ToDoItemDto Update(ToDoItemDto todoItem)
        {
            var result = _toDoRepository.Update(todoItem.Adapt<ToDoItemModel>());
            return result.Adapt<ToDoItemDto>();
        }

        public ToDoItemDto UpdateStatus(int id)
        {
            var item = GetById(id);
            item.Done = !item.Done;
            var result = Update(item);
            return result;
        }

        public List<ToDoItemDto> GetAll()
        {
            var resut = _toDoRepository.GetAll().OrderBy(t => t.Done);
            return resut.Adapt<List<ToDoItemDto>>();
        }

        public ToDoItemDto GetById(int id)
        {
            var result = _toDoRepository.GetById(id);
            return result.Adapt<ToDoItemDto>();
        }
    }
}
