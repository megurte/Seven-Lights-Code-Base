using UnityEngine;

namespace NPC
{
    public class NpcTrade : NpcInteract
    {
        public override void ReleaseAction()
        {
            Debug.Log("Show Trade window");
        }
    }
}