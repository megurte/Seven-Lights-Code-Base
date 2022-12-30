using UnityEngine;

namespace GameLoot
{
    public class ScriptableObjectBase : ScriptableObject
    {
        [SerializeField] private int id;

        public int GetId() => id;
    }
}