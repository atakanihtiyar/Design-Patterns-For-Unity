using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    /// <summary>
    /// Stores and manages commands. 
    /// </summary>
    public class CommandInvoker
    {
        #region Fields

        private Stack<ICommand> _commands;

        #endregion

        #region Functions

        public CommandInvoker()
        {
            _commands = new Stack<ICommand>();
        }

        public void Execute(ICommand command)
        {
            if (command != null)
            {
                command.Execute();
                _commands.Push(command);
            }
        }

        public void Rewind()
        {
            if (_commands.Count != 0)
            {
                ICommand command = _commands.Pop();
                command.Rewind();
            }
        }

        #endregion
    }
}

