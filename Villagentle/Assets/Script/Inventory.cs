using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Me;
    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject Fourth;
    private float hasItem;
    private bool status = false;

    // Update is called once per frame
    void Update()
    {
    hasItem = FindObjectOfType<Move>().Mission();
        if(Input.GetKeyDown(KeyCode.Q))
            {
                if(status == true)
                {
                    status = false;
                    Me.SetActive(false);
                    
                }
                else if(status == false)
                {
                    status = true;
                    Me.SetActive(true);
                    
                }
                
            }
        
        if(hasItem  == 0){
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(false);
        }
        else if(hasItem  == 1){
            First.SetActive(true);
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(false);
        }
        else if(hasItem  == 2){
            Second.SetActive(true);
            First.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(false);
        }
        else if(hasItem  == 3){
            Third.SetActive(true);
            First.SetActive(false);
            Second.SetActive(false);
            Fourth.SetActive(false);
        }
        else if(hasItem  == 4){
            
            Fourth.SetActive(true);
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(false);
        }
        
        
    }
}
