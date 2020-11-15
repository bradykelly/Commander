using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.WebApi.Data;
using Commander.WebApi.Dtos;
using Commander.WebApi.Models;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var destCommand = _repository.GetCommandById(id);
            if (destCommand == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, destCommand);

            _repository.UpdateCommand(destCommand);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var destCommand = _repository.GetCommandById(id);
            if (destCommand == null)
            {
                return NotFound();
            }

            var patchDto = _mapper.Map<CommandUpdateDto>(destCommand);
            patchDoc.ApplyTo(patchDto, ModelState);
            if (!TryValidateModel(patchDto))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(patchDto, destCommand);

            _repository.UpdateCommand(destCommand);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var destCommand = _repository.GetCommandById(id);
            if (destCommand == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(destCommand);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
