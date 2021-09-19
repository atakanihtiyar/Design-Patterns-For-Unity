using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Strategy
{
    internal class FireDamage : IDoDamage
    {
        public void DoDamage(int damage)
        {
            Debug.Log("Fire damage: " + damage);
        }
    }
}

