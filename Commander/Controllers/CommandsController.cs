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
        private readonly ICommanderRepository _commanderRepository;

        public CommandsController(ICommanderRepository commanderRepository)
        {
            _commanderRepository = commanderRepository;
        }
        
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return Ok(_commanderRepository.GetAllCommands());
        }

        //GET  api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            return Ok(_commanderRepository.GetCommandById(id));
        }
    }
}