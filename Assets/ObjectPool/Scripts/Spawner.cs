using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    internal class Spawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool objectPool;

        private void Awake()
        {
            objectPool.Init();
        }

        private void FixedUpdate()
        {
            objectPool.SpawnFromPool(transform.position, Quaternion.identity);
        }
    }
}

