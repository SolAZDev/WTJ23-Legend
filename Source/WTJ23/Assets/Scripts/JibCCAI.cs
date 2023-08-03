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

    bool lookAtTarget;
    public bool LookAtTarget {
        get { return lookAtTarget; }
        set {
            navMeshAgent.updateRotation = !value;
            lookAtTarget=value;
        }
        
    }
    public IAIContext GetContext(System.Guid id) { return context; }
    private void OnEnable() {
        context=new JibaroChupaContext(this);
    }
    public void GoToTarget(bool run){
        Running=run;
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
        animator.SetFloat("Moving", navMeshAgent.velocity.normalized.magnitude>0?(Running?RunSpeed:Speed):0);
        if(LookAtTarget){
            Vector3 rotTarg = (targetPos-transform.position);
            rotTarg.y= transform.position.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotTarg, Vector3.up), Time.deltaTime * (Running?RunSpeed:Speed));
        }
    }

    IEnumerator IResetAudioMemory(){
        yield return new WaitForSeconds(30);
        lastAudioArea=Vector3.zero;
    }


}
