using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    internal class Commander : MonoBehaviour
    {
        private CommandInvoker _invoker;

        private void Start()
        {
            _invoker = new CommandInvoker();
        }

        private void Update()
        {
            Vector3 direction = GetArrowKeyDown();

            if (direction != Vector3.zero)
            {
                ICommand move = new CommandMove(gameObject, direction);
                _invoker.Execute(move);
            }

            var destination = GetClickPosition();

            if (destination != null)
            {
                ICommand moveTo = new CommandMoveTo(gameObject, transform.position, (Vector3)destination);
                _invoker.Execute(moveTo);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                _invoker.Undo();
            }
        }

        private Vector3 GetArrowKeyDown()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Horizontal"))
            {
                return new Vector3(horizontal, 0f, 0f);
            }
            if (Input.GetButtonDown("Vertical"))
            {
                return new Vector3(0f, 0f, vertical);
            }

            return Vector3.zero;
        }

        private Vector3? GetClickPosition()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hitData, 1000))
                {
                    return hitData.point;
                }
            }

            return null;
        }
    }
}

