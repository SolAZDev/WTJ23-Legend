using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CattleAI : BaseActor{
    [Header("AI Settings")]
    public float MaxWalkDistance=5;
    public void MoveAround(){
        navMeshAgent.speed=Speed;
        animator.SetFloat("Moving", .45f);
        navMeshAgent.SetDestination(transform.position+(Random.insideUnitSphere*MaxWalkDistance));
    }
    public void RunAround(){
        navMeshAgent.speed=RunSpeed;
        animator.SetFloat("Moving", 1f);
        navMeshAgent.SetDestination(transform.position+(Random.insideUnitSphere*MaxWalkDistance));
    }
}