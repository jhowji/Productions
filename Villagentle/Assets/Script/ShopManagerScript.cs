using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject B4;

    void Start()
    {
        
        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 20;
        shopItems[2, 4] = 40;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }
    void Update(){
        coins = FindObjectOfType<Move>().Pouch();
        CoinsTXT.text = "Coins:" + coins.ToString();
    }

   
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            if(ButtonRef.GetComponent<ButtonInfo>().ItemID == 1){
                FindObjectOfType<ChangeSkin>().BlueSkin();
                B1.SetActive(false);
                B3.SetActive(true);
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 2){
                FindObjectOfType<ChangeSkin>().RedSkin();
                B2.SetActive(false);
                B4.SetActive(true);
            }
        }


    }
}

