using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseActor : MonoBehaviour
{
    [Header("Actor Settings")]
    [Range(10,50)] public int Health=10;
    [Range(-1,1)]  public float Nervouseness=0;


    [HideInInspector]public bool hasSeenEnemy=false;
    public NavMeshAgent navMeshAgent;

    
    // Start is called before the first frame update
    void Start() { navMeshAgent=GetComponent<NavMeshAgent>();    }


}
