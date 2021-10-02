using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Update
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private List<ScriptableObject> updatableObjects;
        private List<IUpdatable> updatables;

        private void Start()
        {
            updatables = updatableObjects.OfType<IUpdatable>().ToList(); // OfType should be used instead of Cast to avoid potential errors caused by objects that do not inherit IUpdatable. 
            Debug.Log("Updatables count: " + updatables.Count);

            updatables.ForEach(updatable =>
            {
                updatable.OnStart();
            });
        }

        private void Update()
        {
            updatables.ForEach(updatable =>
            {
                updatable.OnUpdate(Time.deltaTime);
            });
        }

        private void OnDestroy()
        {
            updatables.ForEach(updatable =>
            {
                updatable.OnDestroy();
            });
        }
    }
}

