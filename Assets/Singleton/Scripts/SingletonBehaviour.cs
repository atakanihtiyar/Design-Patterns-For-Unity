using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Singleton
{
    /// <summary>
    /// This class makes the derived class non-thread safe singleton. The derived class must be entered as the <typeparamref name="T"/> parameter. 
    /// <para>Tips: If you want to instantiate <typeparamref name="T"/> when the game starts, even if it's not on the scene, read the <c>Init()</c> function documentation.</para>
    /// </summary>
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Fields

        private bool destroyPermission = false;
        private static T instance;

        #endregion

        #region Properties

        public static T Instance {
            get
            {
                Init();
                return instance;
            }
            private set { }
        }

        #endregion

        #region Unity Lifecycle Functions

        private void Awake()
        {
            if (instance == null || instance.Equals(null))
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this as T)
            {
                destroyPermission = true;
                Destroy(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            destroyPermission = true;
        }

        private void OnDestroy()
        {
            if (!destroyPermission)
            {
                instance = null;
                Init();
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// If you want to initialize the <typeparamref name="T"/> when the game starts, even if it's not on the scene, call this function from a static function that uses the <c>[RuntimeInitializeOnLoadMethod]</c> attribute.
        /// <example>
        /// <para>Example: </para>
        /// <code>
        /// [RuntimeInitializeOnLoadMethod]
        /// private static void InitOnLoad()
        /// {
        ///     Init();
        /// }
        /// </code>
        /// </example>
        /// </summary>
        protected static void Init()
        {
            if (FindObjectsOfType<T>().Length > 1)
                throw new System.ArgumentException("Bad things happened! There is more than one [Singleton]" + typeof(T).Name);

            if (instance == null || instance.Equals(null))
            {
                instance = FindObjectOfType<T>();
            }
            if (instance == null || instance.Equals(null))
            {
                GameObject gameObject = new GameObject("[PersistentSingleton] " + typeof(T).Name);
                instance = gameObject.AddComponent<T>();

                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
    }
}
