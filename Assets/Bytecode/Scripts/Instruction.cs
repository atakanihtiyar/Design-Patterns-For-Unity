using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Bytecode
{
    internal enum Instruction
    {
        // Write stats
        INST_SET_HEALTH,
        INST_SET_WISDOM,
        INST_SET_AGILITY,
        INST_PLAY_SOUND,
        INS_SPAWN_PARTICLES,
        // Parameter
        INST_LITERAL,
        // Read stats,
        INST_GET_HEALTH,
        INST_GET_WISDOM,
        INST_GET_AGILITY,
        // Arithmetic
        INST_ADD
    }
}

