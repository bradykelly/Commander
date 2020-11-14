using System.Collections.Generic;
using Commander.WebApi.Models;

namespace Commander.WebApi.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var cmds = new List<Command>
            {
                new Command {Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & pan"},
                new Command {Id = 0, HowTo = "Cut bread", Line = "Get a knife", Platform = "Knife and board"},
                new Command {Id = 0, HowTo = "Make tea", Line = "Place teabag in cup", Platform = "Kettle & cup"}
            };
            return cmds;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}