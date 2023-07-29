using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class Trap : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        if(animator) animator.SetTrigger("Activate");
        if(other.name.Contains("Jibaro")){ /* Jibaro Codo */}
        if(other.name.Contains("Chupacabra")){ /* CabraSucc'r Codo */}
        Activate();
    }

    public abstract void Activate();
    
}