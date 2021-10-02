using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericFactoryMethod
{
    /// <typeparam name="T"><paramref name="T"/> monobehavior to be added to prefab </typeparam>
    public class GenericFactoryMethod<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        /// <summary>
        /// Position and rotation equal (0, 0, 0)
        /// </summary>
        /// <returns><paramref name="T"/>Returns monobehavior of new object</returns>
        public T GetNewInstance()
        {
            return GetNewInstance(Vector3.zero, Quaternion.identity);
        }

        /// <returns>Returns <paramref name="T"/> monobehavior of new object</returns>
        public T GetNewInstance(Vector3 position, Quaternion rotation)
        {
            T obj = GameObject.Instantiate(_prefab, position, rotation).GetComponent<T>();

            if (obj == null) throw new System.ArgumentNullException(typeof(T).Name, "There isn't " + typeof(T).Name + " monobehaviour in prefab.");

            return obj;
        }
    }
}