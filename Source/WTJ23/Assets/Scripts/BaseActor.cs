using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class BaseActor : MonoBehaviour
{
    [Header("Actor Settings")]
    [Range(10,50)] public int Health=10;
    [Range(-1,1)]  public float Nervouseness=0;
    public float Speed=3f, RunSpeed=5f;

    [HideInInspector]public bool hasSeenEnemy=false;
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    
    // Start is called before the first frame update
    public void Start() { 
        navMeshAgent=GetComponent<NavMeshAgent>(); 
        if (!animator) animator=GetComponent<Animator>();
    }




}
