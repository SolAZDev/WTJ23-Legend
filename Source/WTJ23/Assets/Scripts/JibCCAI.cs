using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class JibCCAI : BaseActor{
    [HideInInspector] public Vector3 targetPos, lastAudioArea;
    Coroutine audioReset;
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

    IEnumerator IResetAudioMemory(){
        yield return new WaitForSeconds(30);
        lastAudioArea=Vector3.zero;
    }


}