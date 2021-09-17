using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Singleton
{
    internal class Tester : MonoBehaviour
    {
        private void OnEnable()
        {
            Debug.Log(GameManager.Instance.playerName);
        }
    }
}
