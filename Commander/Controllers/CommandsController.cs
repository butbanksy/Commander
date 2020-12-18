using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
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
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository commanderRepository, IMapper mapper)
        {
            _commanderRepository = commanderRepository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommands()
        {
            var allCommands = _commanderRepository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(allCommands));
        }

        //GET  api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandById = _commanderRepository.GetCommandById(id);
            if (commandById != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandById));
            }

            return NotFound("Command not found");
        }
    }
}