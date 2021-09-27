using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Bytecode
{
    internal class GameManager : MonoBehaviour
    {
        private List<int> wizardHealths;

        private void Start()
        {
            wizardHealths = new List<int>();
            wizardHealths.Add(100);
            wizardHealths.Add(50);

            VirtualMachine virtualMachine = new VirtualMachine(this);
            virtualMachine.Interpret(Bytecode.bytecode);
        }

        public void SetHealth(int wizardID, int amount)
        {
            if (wizardID >= wizardHealths.Count)
                throw new System.ArgumentOutOfRangeException("Wizard id bigger than wizard count");

            wizardHealths[wizardID] = amount;
        }

        public int GetHealth(int wizardID)
        {
            if (wizardID >= wizardHealths.Count)
                throw new System.ArgumentOutOfRangeException("Wizard id bigger than wizard count");

            return wizardHealths[wizardID];
        }
    }
}

