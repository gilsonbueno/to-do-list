using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Business.Interface;
using WebApplication.DataContractObject;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoBusiness _toDoBusiness;
        public ToDoController(IToDoBusiness toDoBusiness)
        {
            this._toDoBusiness = toDoBusiness;
        }

        /// <summary>
        /// Return all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IEnumerable<ToDoItemDto> GetAll()
        {
            var result = _toDoBusiness.GetAll();
            return result;
        }

        /// <summary>
        /// Get one task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ToDoItemDto GetById(int id)
        {
            var result = _toDoBusiness.GetById(id);
            return result;
        }

        /// <summary>
        /// Create a task
        /// </summary>
        /// <param name="toDoItem"></param>
        /// <returns></returns>
        [HttpPost("")]
        public ToDoItemDto Create(ToDoItemDto toDoItem)
        {
            var result = _toDoBusiness.Create(toDoItem);
            return result;
        }

        [HttpPut("")]
        public ToDoItemDto Update(ToDoItemDto toDoItem)
        {
            var result = _toDoBusiness.Update(toDoItem);
            return result;
        }

        /// <summary>
        /// Change the status item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/status")]
        public ToDoItemDto UpdateStatus(int id)
        {
            var result = _toDoBusiness.UpdateStatus(id);
            return result;
        }

        /// <summary>
        /// Delete task by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _toDoBusiness.Delete(id);
        }
    }
}
