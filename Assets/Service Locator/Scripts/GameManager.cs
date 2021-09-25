using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ServiceLocator
{
    internal class GameManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                CoinService.SetService(CoinService.GetService() + 10);
                Debug.Log(CoinService.GetService());
            }
        }
    }
}

