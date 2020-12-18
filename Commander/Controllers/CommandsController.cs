using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandById = _commanderRepository.GetCommandById(id);
            if (commandById != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandById));
            }

            return NotFound("Command not found");
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<Command>(commandCreateDto);
            _commanderRepository.CreateCommand(command);
            _commanderRepository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute("GetCommandById", new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandCreateDto commandCreateDto)
        {
            var commandById = _commanderRepository.GetCommandById(id);
            if (commandById == null)
            {
                return NotFound();
            }

            _mapper.Map(commandCreateDto, commandById);
            _commanderRepository.UpdateCommand(commandById);
            _commanderRepository.SaveChanges();
            
            return Ok(commandById);
        }
    }
}