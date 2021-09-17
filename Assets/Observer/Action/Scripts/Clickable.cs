using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Action
{
    internal class Clickable : MonoBehaviour
    {
        public static Action<GameObject, Vector3> OnSomeoneClickedOnMe;

        private void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, 1000))
            {
                SomeoneClickedOnMe(hitData.point);
            }
        }

        private void SomeoneClickedOnMe(Vector3 mouseLocalPositionOnMe)
        {
            OnSomeoneClickedOnMe?.Invoke(gameObject, mouseLocalPositionOnMe);
        }
    }
}

