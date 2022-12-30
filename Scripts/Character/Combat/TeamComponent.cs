using UnityEngine;

namespace Character.Combat
{
    public enum TeamIndex : sbyte
    {
        None = -1,
        Neutral = 0,
        Player,
        Enemy,
        Count
    }

    public class TeamComponent : MonoBehaviour
    {
        [SerializeField] private TeamIndex teamIndex = TeamIndex.None;
        
        public TeamIndex TeamIndex
        {
            set
            {
                if (teamIndex == value)
                {
                    return;
                }

                teamIndex = value;

           
            }
            get => teamIndex;
        }
    }
}