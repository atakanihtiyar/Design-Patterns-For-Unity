using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Bytecode
{
    internal class Bytecode // class to write the bytecode
    {
        public static readonly int[] bytecode = new int[]
        {
        (int)Instruction.INST_LITERAL, 0, // wizard id
        (int)Instruction.INST_GET_HEALTH,

        (int)Instruction.INST_LITERAL, 0, // wizard id
        (int)Instruction.INST_LITERAL, 75, // amount
        (int)Instruction.INST_SET_HEALTH,

        (int)Instruction.INST_LITERAL, 0, // wizard id
        (int)Instruction.INST_GET_HEALTH,

        (int)Instruction.INST_LITERAL, 1, // wizard id
        (int)Instruction.INST_GET_HEALTH,
        };
    }
}

