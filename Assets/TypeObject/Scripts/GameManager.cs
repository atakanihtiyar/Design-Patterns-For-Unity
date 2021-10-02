using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.TypeObject
{
    internal class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Bird owl = new Bird("owl", true);
            Bird penguin = new Bird("penguin", false);
            Fish flyingFish = new Fish("flying fish", true);

            owl.Talk();
            penguin.Talk();
            flyingFish.Talk();
        }
    }
}

