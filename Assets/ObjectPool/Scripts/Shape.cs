using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    internal class Shape : MonoBehaviour, IPoolable
    {
        [SerializeField] private float upForce = 1f;
        [SerializeField] private float sideForce = .1f;

        public void OnSpawn()
        {
            float xForce = Random.Range(-sideForce, sideForce);
            float yForce = Random.Range(upForce / 2, upForce);
            float zForce = Random.Range(-sideForce, sideForce);

            Vector3 force = new Vector3(xForce, yForce, zForce);

            GetComponent<Rigidbody>().velocity = force;
        }
    }
}

