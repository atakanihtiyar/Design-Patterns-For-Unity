using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericFactoryMethod
{
    internal class Enemy : MonoBehaviour
    {
        internal int health = 0;

        private void Awake()
        {
            health = 100;
            Debug.Log("Enemy initiliazed");
        }
    }
}

