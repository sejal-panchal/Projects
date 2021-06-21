using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands=new List<Command>
            {
                new Command{Id=1, HowTo="Boil an egg", Line="boil water", Platform="Kettle & Pan"},
                new Command{Id=2, HowTo="freezed lunch", Line="bowl", Platform="Microwave"},
                new Command{Id=3, HowTo="Make tea", Line="place teabag in water", Platform="Kettle & cup"}
            };

            return commands;
        }

        public Command GetCommand(int Id)
        {
            return new Command{Id=1, HowTo="Boil an egg", Line="boil water", Platform="Kettle & Pan"};
        }
    }
}