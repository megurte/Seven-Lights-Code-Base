using System;
using UnityEngine.Serialization;

namespace GameLoot
{
    [Serializable]
    public class LootSettings
    {
        public Loot loot;
        public int count;
        public float chance;
    }
}