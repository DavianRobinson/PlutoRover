using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public string CommandName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Execute(Rover rover)
        {
            rover.TurnLeft();
        }
    }
}
