using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Update
{
    [CreateAssetMenu(fileName = "New enemy", menuName = "Update/Enemy")]
    internal class Enemy : ScriptableObject, IUpdatable
    {
        [SerializeField] private int startHealth = 100;
        [SerializeField] private int health = 0;

        public void OnStart()
        {
            health = startHealth;
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                health -= 10;
                Debug.Log("Health: " + health + "\nDelta time: " + deltaTime);
            }
        }

        public void OnDestroy()
        {
            health = 0;
        }
    }
}

