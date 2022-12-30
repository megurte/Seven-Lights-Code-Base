using UnityEngine;

namespace NPC
{
    public class NpcDialogue : NpcInteract
    {
        public override void ReleaseAction()
        {
            Debug.Log("Show Dialogue window");
        }
    }
}