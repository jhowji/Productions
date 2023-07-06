using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGold : MonoBehaviour
{
    public Material[] material;
    public float goal;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        ++ChangeBlue.goal;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
    void update(){
         goal = ++ChangeBlue.goal;
    }

    void OnCollisionEnter (Collision col) 
    {
        if(col.gameObject.tag == "Player")
        {
            rend.sharedMaterial = material[1];
            ChangeBlue.goal = 4;
        }
    }
}
