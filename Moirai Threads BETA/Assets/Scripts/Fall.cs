using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour

{
    public Collider coll;
    public int N = 0;
    void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }

    // Disables gravity on all rigidbodies entering this collider.
    void OnTriggerEnter(Collider other)
    {
        N += 1;
        if(N > 1500){
            if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = false;
    }
        }
        
}