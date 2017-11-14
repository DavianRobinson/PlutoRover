using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain.Commands
{
    public interface ICommand
    {
        string CommandName { get; }
        void Execute(Rover rover);
   
    }
}
