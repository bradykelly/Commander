using System.Collections.Generic;
using Commander.Models;

namespace Commander.WebApi.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            throw new System.NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            return new Command {Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan"};
        }
    }
}