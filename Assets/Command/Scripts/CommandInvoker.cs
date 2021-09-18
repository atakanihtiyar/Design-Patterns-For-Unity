using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    /// <summary>
    /// Command invoker class. Stores and manages commands. 
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

        /// <summary>
        /// Execute given command
        /// </summary>
        /// <param name="command">Command to execute</param>
        public void Execute(ICommand command)
        {
            if (command != null)
            {
                command.Execute();
                _commands.Push(command);
            }
        }

        /// <summary>
        /// Undo last command
        /// </summary>
        public void Undo()
        {
            if (_commands.Count != 0)
            {
                ICommand command = _commands.Pop();
                command.Undo();
            }
        }

        #endregion
    }
}

