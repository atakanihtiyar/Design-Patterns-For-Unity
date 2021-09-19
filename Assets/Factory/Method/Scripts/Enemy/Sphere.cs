using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryMethod
{
    public class Sphere : MonoBehaviour, IEnemy
    {
        public void Walk()
        {
            Debug.Log("Sphere walking...");
        }
    }
}

