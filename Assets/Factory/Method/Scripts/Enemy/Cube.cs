using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryMethod
{
    public class Cube : MonoBehaviour, IEnemy
    {
        public void Walk()
        {
            Debug.Log("Cube walking...");
        }
    }
}

