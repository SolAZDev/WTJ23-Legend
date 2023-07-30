using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JibCCAI : BaseActor{
    [HideInInspector] public Vector3 targetPos;
    public void GoToTarget(bool run){
        animator.SetFloat("Moving", run ? 1 : .49f);
        navMeshAgent.speed = run ? RunSpeed : Speed;
        navMeshAgent.SetDestination(targetPos);
    } 

    
}