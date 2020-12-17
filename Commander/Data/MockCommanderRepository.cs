using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command()
                {
                    HowTo = "Boil an egg",
                    Id = 1,
                    Line = "boil egg",
                    Platform = "Mac OS X"
                },
                new Command()
                {
                    HowTo = "Boil an egg",
                    Id = 1,
                    Line = "boil egg",
                    Platform = "Mac OS X"
                },
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command()
            {
                HowTo = "Boil an egg",
                Id = 1,
                Line = "boil egg",
                Platform = "Mac OS X"
            };
        }
    }
}