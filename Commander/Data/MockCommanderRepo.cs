using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands=new List<Command> {
                new Command{Id=1,HowTo="boil sweet potato", Line="Boil water", Platform="Kettle & Pan"},
                new Command{Id=2,HowTo="make sandwich", Line="toast bread", Platform="spatula & Pan"},
                new Command{Id=3,HowTo="make salad", Line="cut vegetables", Platform="knife & bowl"}
            };

            return commands;
        }

        public Command GetCommandByID(int id)
        {
            return new Command{Id=0,HowTo="boil potato", Line="Boil water", Platform="Kettle & Pan"};
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Command> ICommanderRepo.GetAllCommands()
        {
            throw new System.NotImplementedException();
        }

        Command ICommanderRepo.GetCommandByID(int id)
        {
            throw new System.NotImplementedException();
        }

        bool ICommanderRepo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}