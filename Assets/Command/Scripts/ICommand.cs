using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    /// <summary>
    /// Command interface
    /// </summary>
    public interface ICommand
    {
        #region Functions

        void Execute();
        void Undo();

        #endregion
    }
}

