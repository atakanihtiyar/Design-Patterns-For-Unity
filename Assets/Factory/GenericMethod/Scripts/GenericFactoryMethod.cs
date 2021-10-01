using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericFactoryMethod
{
    /// <summary>
    /// Generic class for factory design pattern
    /// </summary>
    /// <typeparam name="T"><paramref name="T"/> monobehavior of prefab to be created</typeparam>
    public class GenericFactoryMethod<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        /// <summary>
        /// Instantiate prefab
        /// <para>Position and rotation equal (0, 0, 0)</para>
        /// </summary>
        /// <returns><paramref name="T"/> monobehavior of new object</returns>
        public T GetNewInstance()
        {
            return GetNewInstance(Vector3.zero, Quaternion.identity);
        }

        /// <summary>
        /// Instantiate prefab
        /// </summary>
        /// <param name="position">Position to instantiate</param>
        /// <param name="rotation">Rotation to instantiate</param>
        /// <returns>Returns <paramref name="T"/> monobehavior of new object</returns>
        public T GetNewInstance(Vector3 position, Quaternion rotation)
        {
            T obj = GameObject.Instantiate(_prefab, position, rotation).GetComponent<T>();

            if (obj == null) throw new System.ArgumentNullException(typeof(T).Name, "There isn't " + typeof(T).Name + " monobehaviour in prefab.");

            return obj;
        }
    }
}