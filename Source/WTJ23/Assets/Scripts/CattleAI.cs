using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Apex.AI;
using Apex.AI.Components;

public class CattleAI : BaseActor, IContextProvider{
    [Header("AI Settings")]
    public float MaxWalkDistance=5;
    public float MaxRunDistance=30;
    public IAIContext GetContext(System.Guid id) { return context; }
    CattleContext context;
    void Start() {
        base.Start();
        context = new CattleContext(this);
    }
    public void MoveAround(){
        Running=false;
        navMeshAgent.speed=Speed;
        // animator.SetFloat("Moving", .45f);
        navMeshAgent.SetDestination(transform.position+(Random.insideUnitSphere*MaxWalkDistance));
    }
    public void RunAround(){
        Running=true;
        navMeshAgent.speed=RunSpeed;
        // animator.SetFloat("Moving", 1f);
        navMeshAgent.SetDestination(transform.position+(Random.insideUnitSphere*MaxWalkDistance));
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag=="Chupa") OnPerish();
    }

    private void Update() {
        animator.SetFloat("Moving", navMeshAgent.velocity.normalized.magnitude>0?(Running?RunSpeed:Speed):0);
        // animator.SetFloat("Moving", navMeshAgent.remainingDistance);
    }
}