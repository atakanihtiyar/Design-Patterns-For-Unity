using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    internal class PlayState : State<GameManager>
    {
        public override void EnterState(GameManager t)
        {
            Debug.Log("Enter play state");
        }

        public override void OnCollisionEnter(GameManager t)
        {

        }

        public override void Update(GameManager t)
        {

        }
    }
}

