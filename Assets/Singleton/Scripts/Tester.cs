using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Singleton
{
    internal class Tester : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Player name: " + GameManager.Instance.playerName);
        }
    }
}
