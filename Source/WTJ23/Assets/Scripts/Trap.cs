using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Trap : MonoBehaviour
{
    Rigidbody rigidbody;
    Collider collider;
    public Animator animator;
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
        collider=GetComponent<Collider>();
    }

     void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag=="Floor"){
            rigidbody.isKinematic=true;
            collider.isTrigger=true;
        }
    }
    
}