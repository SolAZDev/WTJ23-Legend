using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BaseActor : MonoBehaviour
{
    [Header("Actor Settings")]
    [Range(10,50)] public int Health=10;
    [Range(-1,1)]  public float Nervouseness=0;
    public float Speed=3f, RunSpeed=5f;
    public bool CanMove;
    [HideInInspector]public bool hasSeenEnemy=false;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Rigidbody RB;


    public float TimeToDecreaseNervousness=3f, NervousnessDecreaseRate=.03f;
    
    // Start is called before the first frame update
    public void Start() { 
        navMeshAgent=GetComponent<NavMeshAgent>(); 
        if (!animator) animator=GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            RecieveDamage(10);
            StartCoroutine(StopMoving());
        }
        else if (other.tag == "ChupaMouth") RecieveDamage(15);
        else if (other.tag == "ChupaClaw") RecieveDamage(8);
        else if (other.tag == "Machete") RecieveDamage(10);
    }

    void RecieveDamage(int damage){
        Health-=damage;
        // Ay me mori
        if (Health<=0) OnPerish();
        //else audioSource.play(Pain)
    }

    public void ToggleNavMeshRigid(){
        RB.isKinematic=!RB.isKinematic;
        navMeshAgent.enabled=!navMeshAgent.enabled;
        print(RB.isKinematic);
    }



    IEnumerator DecreaseNervousness(){
        while(Health>0){
            yield return new WaitForSeconds(TimeToDecreaseNervousness);
            this.Nervouseness-=NervousnessDecreaseRate;
        }
    }

    public void SendAbility(string args)
    {
        SendMessage("Ability" + args);
    }

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(Random.Range(3,5));
        CanMove=true;
    }

     public void OnPerish(){
        gameObject.tag="Perished";
        //TODO: Play PerishSound
        BroadcastMessage("HeardDeath", transform.position);
        animator.SetTrigger("Perish");
        StartCoroutine(PostPerishExpiration());
    }

    IEnumerator PostPerishExpiration(){
        yield return new WaitForSeconds(30);
        gameObject.SetActive(false);
    }
}
