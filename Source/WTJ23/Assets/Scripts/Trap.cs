using UnityEngine;

[RequireComponent(typeof(RigidBody))]
[RequireComponent(typeof(BoxCollider))]
public class Trap : MonoBehaviour
{
    Rigidbody rigidbody;
    Collider collider;
    public Animator animator;

    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
        collider=GetComponent<collider>();
    }

     void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag=="Floor"){
            rigidbody.isKinematic=true;
            collider.isTrigger=true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(animator) animator.SetTrigger("Activate");
        if(other.name==""){}
    }
    
}