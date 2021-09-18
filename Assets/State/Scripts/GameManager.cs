using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    internal class GameManager : DesignPatterns.Singleton.SingletonBehaviour<GameManager>
    {
        private State<GameManager> _currentState;

        public readonly PlayState PlayState = new PlayState();
        public readonly PauseState PauseState = new PauseState();

        private void Start()
        {
            TransitionToState(PauseState);
        }

        private void Update()
        {
            _currentState.Update(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _currentState.OnCollisionEnter(this);
        }

        public void TransitionToState(State<GameManager> state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }

        public void TransitionToPlay()
        {
            TransitionToState(PlayState);
        }

        public void TransitionToPause()
        {
            TransitionToState(PauseState);
        }
    }
}

