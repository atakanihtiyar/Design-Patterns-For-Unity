using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    /// <summary>
    /// Object pool class
    /// </summary>
    [System.Serializable]
    public class ObjectPool
    {
        [System.Serializable]
        private class PoolObject
        {
            public GameObject prefab;
            public int count;
        }

        private Queue<GameObject> _pool = null;
        [SerializeField] private List<PoolObject> prefabsToBePooled;

        /// <summary>
        /// Initializes the pool. Call this function before.
        /// </summary>
        public void Init()
        {
            _pool = new Queue<GameObject>();

            prefabsToBePooled.ForEach(prefabToPooled =>
            {
                for (int i = 0; i < prefabToPooled.count; i++)
                {
                    GameObject obj = GameObject.Instantiate(prefabToPooled.prefab);
                    obj.SetActive(false);
                    _pool.Enqueue(obj);
                }
            });
        }

        /// <summary>
        /// Returns the next object from the pool queue.
        /// </summary>
        /// <param name="position">Position for new object</param>
        /// <param name="rotation">Rotation for new object</param>
        /// <returns></returns>
        public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
        {
            if (_pool == null)
            {
                throw new ArgumentNullException("Object pool not initialized. Use Init() for fix it.");
            }

            GameObject objectToSpawn = _pool.Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPoolable poolable = objectToSpawn.GetComponent<IPoolable>();
            if (poolable != null)
            {
                poolable.OnSpawn();
            }

            _pool.Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}

