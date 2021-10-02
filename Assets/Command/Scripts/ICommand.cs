using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public interface ICommand
    {
        #region Functions

        void Execute();
        void Rewind();

        #endregion
    }
}

