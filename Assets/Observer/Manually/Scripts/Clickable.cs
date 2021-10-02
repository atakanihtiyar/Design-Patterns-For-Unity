using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Manual
{
    internal class Clickable : Subject
    {
        private void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, 1000))
            {
                SomeoneClickedOnMe(hitData.point);
            }
        }

        public void SomeoneClickedOnMe(Vector3 mousePosition)
        {
            Notify(gameObject, mousePosition);
        }
    }
}
