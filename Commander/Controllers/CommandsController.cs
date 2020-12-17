using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    //[controller] takes the class name without the Controller 
    [ApiController]
    public class CommandsController : ControllerBase
    {
        //TODO: Add dependancy injection
        private readonly MockCommanderRepository _repository = new MockCommanderRepository();

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return Ok(_repository.GetAllCommands());
        }

        //GET  api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            return Ok(_repository.GetCommandById(id));
        }
    }
}