using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCs : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogueWin;
    public string[] dialogue;
    private int index;
    public GameObject Cat;

    public GameObject contButton;
    public GameObject CatArrived;
    public float wordSpeed;
    public bool playerIsClose; 
    public float NPCID;
    private float Item;
    

    // Update is called once per frame
    void Update()
    {
       
        
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
             Item = FindObjectOfType<Move>().Mission();
            //Check if you have the right item
            if(NPCID == Item){
            FindObjectOfType<Move>().Complete();
                if(Item == 4){
                    Cat.SetActive(false);
                    CatArrived.SetActive(true);
                }
            //Trigger new dialogue
            dialogue = dialogueWin;
            NPCID = 77;
            }
            if (dialoguePanel.activeInHierarchy)
            {
                NextLine();

            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        else if(playerIsClose == false)
        {
            zeroText();
        }
        
        
        if(dialogueText.text == dialogue[index]){
            contButton.SetActive(true);
        }
    }
    public void zeroText(){

        contButton.SetActive(false);

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {

        contButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index ++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
            
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
            
    }
}
