using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain.Commands 
{
    public class UnknownCommand : ICommand
    {
        private string _commandName;

        public string CommandName 
        {
            get
            {
                return _commandName;
            }
        }
        public UnknownCommand(string commandName)
        {
            _commandName = commandName;
        }
        public void Execute(Rover rover)
        {
            Console.WriteLine("Unknown Command:" + _commandName);
        }
    }
}
