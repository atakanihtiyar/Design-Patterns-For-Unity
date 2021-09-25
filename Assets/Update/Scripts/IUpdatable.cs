using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Update
{
    internal interface IUpdatable
    {
        void OnStart();
        void OnUpdate(float deltaTime);
        void OnDestroy();
    }
}

