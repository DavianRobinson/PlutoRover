using PlutoRover.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain
{
   
    public class CommandParser
    {
        private List<ICommand> _availableCommands = new List<ICommand>();
        readonly Dictionary<string, ICommand> _knownCommands = new Dictionary<string, ICommand>
        {
        {"F",new MoveForwardCommand() },
        {"B",new MoveBackCommand()},
        {"L",new TurnLeftCommand() },
        {"R",new TurnRightCommand() }

        };
        public CommandParser()
        {

        }
        public CommandParser(Dictionary<string,ICommand> systemCommands)
        {
            _knownCommands = systemCommands;

        }
        public CommandParser(string commandString)
        {
            var commands = commandString.Split().ToList();
           
        }
        public List<ICommand> ToCommand(string commandString)
        {            
            return Parse(commandString.ToCharArray());
        }

        private List<ICommand> Parse(char[] commandName)
        {
            foreach (var strCommand in commandName)
            {
                var commnd = strCommand.ToString();
                if (_knownCommands.ContainsKey(commnd))
                    _availableCommands.Add(ParseCommand(commnd));
            }

            return _availableCommands;
        }

        private ICommand ParseCommand(string commandName)
        {            
            var commandFound = _knownCommands[commandName];
            if (commandFound == null)
                return new UnknownCommand(commandName);
            return commandFound;
        } 
        
    }
}
