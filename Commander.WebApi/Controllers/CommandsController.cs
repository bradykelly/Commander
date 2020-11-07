using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
using Commander.WebApi.Data;

namespace Commander.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo commanderRepo)
        {
            _repository = commanderRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var cmdItems = _repository.GetAppCommands();
            return Ok(cmdItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var cmd = _repository.GetCommandById(id);
            return Ok(cmd);
        }
    }
}
