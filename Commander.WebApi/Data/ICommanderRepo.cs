using System.Collections.Generic;
using Commander.Models;

namespace Commander.WebApi.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}