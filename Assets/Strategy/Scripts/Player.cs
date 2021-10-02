using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Strategy
{
    internal class Player : MonoBehaviour
    {
        private readonly Dagger FireDagger = new Dagger(40, new FireDamage());
        private readonly Dagger IceDagger = new Dagger(20, new IceDamage());

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                FireDagger.TryToAttack();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                IceDagger.TryToAttack();
            }
        }
    }
}

