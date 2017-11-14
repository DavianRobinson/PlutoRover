using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoRover.Domain.Commands;

namespace PlutoRover.Domain
{
    public class Rover
    {
       
        private Vector _vector;
        public Rover(Planet planet, Coordinates coordinates, Direction direction)
        {          
            _vector = new Vector(coordinates, direction, planet);
        }

        public void Run(string commands)
        {
            var commandToProcess = new CommandParser().ToCommand(commands);
            foreach (var command in commandToProcess)
            {
                command.Execute(this);
            }

        }

        public void MoveForward()
        {
            _vector.MoveForward();
        }
        public void MoveBackwards()
        {
            _vector.MoveBackwards();
        }
        public void TurnLeft()
        {
            _vector.TurnRight();
        }
        public void TurnRight()
        {
            _vector.TurnRight();
        }

        public string CurrentLocation()
        {
            return _vector.CurrentLocation();            
        }
    }
}
