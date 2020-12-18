using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _commanderContext;

        public SqlCommanderRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commanderContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(command => command.Id == id);
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _commanderContext.Add(command);
            
        }

        public bool SaveChanges()
        {
            return (_commanderContext.SaveChanges() >= 0);
        }
    }
}