using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Apex.AI;
using Apex.AI.Components;
public class JibCCAI : BaseActor,IContextProvider {
    [HideInInspector] public Vector3 targetPos, lastAudioArea;
    Coroutine audioReset;
    JibaroChupaContext context;
    public IAIContext GetContext(System.Guid id) { return context; }
    private void OnEnable() {
        context=new JibaroChupaContext(this);
    }
    public void GoToTarget(bool run){
        animator.SetFloat("Moving", run ? 1 : .49f);
        navMeshAgent.speed = run ? RunSpeed : Speed; 
        navMeshAgent.SetDestination(targetPos);
    } 

    public void OnHeardDeath(Vector3 position) => lastAudioArea=position;
    public void OnHeardWou(Vector3 position) => lastAudioArea=position;

    public void ResetAudioMemory(Vector3 position){
        if(audioReset!=null) StopCoroutine(audioReset);
        lastAudioArea=position;
        StartCoroutine(IResetAudioMemory());
    }

    void Update(){
        animator.SetFloat("Moving", navMeshAgent.velocity.magnitude);
    }

    IEnumerator IResetAudioMemory(){
        yield return new WaitForSeconds(30);
        lastAudioArea=Vector3.zero;
    }


}
