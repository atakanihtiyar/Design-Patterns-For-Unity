using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    internal class CommandMoveTo : ICommand
    {
        private readonly Vector3 _startPosition;
        private readonly Vector3 _destinationPosition;
        private readonly GameObject _gameObject;

        internal CommandMoveTo(GameObject obj, Vector3 startPosition, Vector3 destinationPosition)
        {
            _startPosition = startPosition;
            _destinationPosition = destinationPosition;
            _gameObject = obj;
        }

        public void Execute()
        {
            _gameObject.transform.position = _destinationPosition;
        }

        public void Rewind()
        {
            _gameObject.transform.position = _startPosition;
        }
    }
}

