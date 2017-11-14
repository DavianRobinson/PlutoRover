using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain.Commands
{
    public class MoveForwardCommand : ICommand
    {
        private const string _commandName ="MoveForawardCommand";

       
        public string CommandName
        {
            get
            {
                return _commandName;
            }
          
        }

        public void Execute(Rover rover)
        {
            rover.MoveForward();
        }
    }
}
