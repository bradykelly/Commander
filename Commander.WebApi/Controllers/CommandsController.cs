using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.WebApi.Data;
using Commander.WebApi.Dtos;
using Commander.WebApi.Models;

namespace Commander.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _repository = commanderRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var cmdItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(cmdItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var cmd = _repository.GetCommandById(id);
            if (cmd != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(cmd));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto createDto)
        {
            var createCmd = _mapper.Map<Command>(createDto);
            _repository.CreateCommand(createCmd);
            _repository.SaveChanges();
            var readDto = _mapper.Map<CommandReadDto>(createCmd);

            return CreatedAtRoute(nameof(GetCommandById), new {id = readDto.Id}, readDto);
        }
    }
}
