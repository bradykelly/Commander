using System;
using System.Collections.Generic;
using System.Linq;
using Commander.WebApi.Models;

namespace Commander.WebApi.Data
{
    class PostgresCommanderRepo : ICommanderRepo
    {
        private CommanderContext _context;

        public PostgresCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }
    }
}