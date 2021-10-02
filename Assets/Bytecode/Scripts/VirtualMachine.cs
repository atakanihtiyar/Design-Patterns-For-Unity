using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Bytecode
{
    internal class VirtualMachine
    {
        private GameManager _gameManager;

        private Stack<int> stackMachine = new Stack<int>(); // to temporarily store values in bytecode
        private const int MAX_STACK = 128;

        public VirtualMachine(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Interpret(int[] bytecode)
        {
            stackMachine.Clear();

            for (int i = 0; i < bytecode.Length; i++)
            {
                Instruction instruction = (Instruction)bytecode[i];

                switch (instruction)
                {
                    case Instruction.INST_SET_HEALTH:
                        {
                            int amount = Pop();
                            int wizard = Pop();

                            _gameManager.SetHealth(wizard, amount);

                            Debug.Log($"Wizard {wizard}'s health sets to {amount}");

                            break;
                        }
                    case Instruction.INST_LITERAL:
                        {
                            Push(bytecode[++i]);

                            break;
                        }
                    case Instruction.INST_GET_HEALTH:
                        {
                            int wizard = Pop();

                            Push(_gameManager.GetHealth(wizard));

                            Debug.Log($"Wizard {wizard}'s health {_gameManager.GetHealth(wizard)}");

                            break;
                        }
                    case Instruction.INST_ADD:
                        {
                            int right = Pop();
                            int left = Pop();

                            Push(right + left);

                            break;
                        }
                    default:
                        {
                            Debug.LogError($"The virtual machine couldn't find the instruction{instruction}");
                            break;
                        }
                }
            }
        }

        private int Pop()
        {
            if (stackMachine.Count == 0)
            {
                throw new System.InvalidOperationException("Trying pop from bytecode stack but the stack is empty");
            }

            return stackMachine.Pop();
        }

        private void Push(int number)
        {
            if (stackMachine.Count + 1 > MAX_STACK)
            {
                throw new System.StackOverflowException("Trying push to bytecode stack but the stack is full");
            }

            stackMachine.Push(number);
        }
    }
}

