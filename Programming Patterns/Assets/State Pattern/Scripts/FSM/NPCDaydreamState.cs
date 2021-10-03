using UnityEngine;
using UnityEngine.AI;

public class DaydreamState : INPCState
{
    private float count = 0;

    public INPCState DoState(NPCSearch_ClassBased npc)
    {
        //pre-conditions
        if (npc.navAgent == null)
            npc.navAgent = npc.GetComponent<NavMeshAgent>();

        //action
        StandStill(npc);

        //post-conditions
        //if (CanSeeCritter())
        //    npcMode = NPCMode.attack;
        //else if (CanSeePickUp())
        //    npcMode = NPCMode.collect;
        if (count > 1)
        {
            count = 0;
            return npc.wanderState;
        }
        else
            return npc.daydreamState;
    }

    private void StandStill(NPCSearch_ClassBased npc)
    {
        if(npc.navAgent.destination != npc.navAgent.transform.position)
        npc.navAgent.SetDestination(npc.navAgent.transform.position);
        count = count + Time.deltaTime;
        //if (npc.navAgent.destination != npc.critterTarget.transform.position)
        //    npc.navAgent.SetDestination(npc.critterTarget.transform.position);
    }
}
