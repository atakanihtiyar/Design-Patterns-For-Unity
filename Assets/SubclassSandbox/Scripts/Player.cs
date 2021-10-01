using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SubclassSandbox
{
    internal class Player : MonoBehaviour
    {
        private List<SuperPower> superPowers;

        private void Start()
        {
            superPowers = new List<SuperPower>();
            superPowers.Add(new Fireball());
            superPowers.Add(new Snowball());
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                superPowers[0].Activate();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                superPowers[1].Activate();
            }
        }
    }
}