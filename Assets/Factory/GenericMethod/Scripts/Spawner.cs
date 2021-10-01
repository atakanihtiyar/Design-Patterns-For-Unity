
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericFactoryMethod
{
    internal class Spawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory enemyFactory;
        private Enemy enemy = null;

        private void Start()
        {
            enemyFactory.GetNewInstance();
            enemyFactory.GetNewInstance(Vector3.right * 2, Quaternion.Euler(45, 45, 45));
            enemy = enemyFactory.GetNewInstance(Vector3.left * 2, Quaternion.Euler(33, 33, 33));
            Debug.Log(enemy.health);
        }
    }
}

