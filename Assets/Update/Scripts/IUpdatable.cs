using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdatable
{
    void OnStart();
    void OnUpdate(float deltaTime);
    void OnDestroy();
}
