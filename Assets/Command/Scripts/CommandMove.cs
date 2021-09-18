using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    internal class CommandMove : ICommand
    {
        private readonly Vector3 _direction;
        private readonly GameObject _gameObject;

        internal CommandMove(GameObject obj, Vector3 direction)
        {
            _direction = direction;
            _gameObject = obj;
        }

        public void Execute()
        {
            _gameObject.transform.position += _direction;
        }

        public void Undo()
        {
            _gameObject.transform.position -= _direction;
        }
    }
}

