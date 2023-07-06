using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBlue : MonoBehaviour
{
    public static float goal;
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void OnCollisionEnter (Collision col) 
    {
        if(col.gameObject.tag == "Player")
        {
            rend.sharedMaterial = material[1];
        }
    }
}
