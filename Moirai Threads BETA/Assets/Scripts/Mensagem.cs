using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mensagem : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public TextMeshProUGUI texto2;
    public TextMeshProUGUI texto3;
    public float dist = 3;
    private GameObject Norra;
    // Start is called before the first frame update
    void Start()
    {
        texto.enabled = false;
        texto2.enabled = false;
        texto3.enabled = false;
        Norra = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Norra.transform.position) < dist){
            texto.enabled = true;
            texto2.enabled = true;
            texto3.enabled = true;
        }
        else{
            texto.enabled = false;
            texto2.enabled = false;
            texto3.enabled = false;
        }
    }
}
