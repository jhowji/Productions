using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreDoor : MonoBehaviour
{
    public Collider2D coll;

    public Camera First;
    public Camera Second;

    //public bool MainCam = true;
     void Start()
    {
        //Collider Detection On
        coll = GetComponent<Collider2D>();
        coll.isTrigger = true;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            
                First.depth = 0;
                Second.depth = 1;
              
        }
            
    }
    void Update()
    {
        
    }
}
