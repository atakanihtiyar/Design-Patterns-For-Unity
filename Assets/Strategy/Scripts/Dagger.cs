using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Strategy
{
    internal class Dagger : WeaponBase
    {
        internal Dagger(int damage, IDoDamage damageType)
        {
            _damage = damage;
            _damageType = damageType;
        }
    }
}
