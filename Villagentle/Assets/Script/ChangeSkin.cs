using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    //Get skins animation
    
    public AnimatorOverrideController blue;
    public AnimatorOverrideController red;
    public AnimatorOverrideController green;
    
    [SerializeField] bool GotBlue = false;
    [SerializeField] bool GotRed = false;
   
    public void BaseSkin(){
        GetComponent<Animator>().runtimeAnimatorController = green as RuntimeAnimatorController;
    }

    public void BlueSkin(){
        GetComponent<Animator>().runtimeAnimatorController = blue as RuntimeAnimatorController;
        GotBlue = true;
    }
    public void RedSkin(){
        GetComponent<Animator>().runtimeAnimatorController = red as RuntimeAnimatorController;
        GotRed = true;
    }
    //Check if player bought something
    public bool HasBlue(){
        return GotBlue;
    }
    public bool HasRed(){
        return GotRed;
    }
}
