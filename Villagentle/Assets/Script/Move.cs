using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //Physics
    public Rigidbody2D rb2;
    Vector2 Movement;
    public float Speed = 30f;
    public Collider2D coll;
    //Animation and position
    public Vector2 startPosition;
    public Vector2 backPosition;
    public Animator anim;
    public static Move instance;

    public GameObject Shop;
    public GameObject press;
    public string nomeDaCena;
    //Values
    private bool blueSkin;
    private bool redSkin;
    public float Money;
    public float MissionID;
    private float LastItem;

    
    public GameObject Inventory;

    void Start(){
        coll = GetComponent<Collider2D>();
        
        if(instance != null){
            Destroy(this.gameObject);
            return;
        }
        
        instance = this;
        //GameObject.DontDestroyOnLoad(this.gameObject);

    }
    void Update()
    {
        
        //Confirm that you have the outfit
        blueSkin = FindObjectOfType<ChangeSkin>().HasBlue();
        redSkin = FindObjectOfType<ChangeSkin>().HasRed();

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        //Transform moviment valor in animation paramenter 
        anim.SetFloat("hori", Movement.x);
        anim.SetFloat("vert", Movement.y);
        anim.SetFloat("Speed", Movement.sqrMagnitude);
        if(Input.GetKeyDown(KeyCode.E))
            {
                press.SetActive(false);
                MissionID = LastItem;
                
            }

    }
    void FixedUpdate ()
    {
        //Movement of the player
        rb2.MovePosition(rb2.position + Movement * Speed * Time.fixedDeltaTime);
    }
     public void OnTriggerEnter2D(Collider2D other)
    {
        //In and Out of the shop
        if(other.CompareTag("Respawn")){
            transform.position = startPosition;
            Shop.SetActive(true);
        }
        else if(other.CompareTag("Finish")){
            transform.position = backPosition;
            Shop.SetActive(false);
            //Endgame
            if(blueSkin == true && redSkin == true)
            {
                SceneManager.LoadScene(nomeDaCena);
            }
        }
        //Show "E" buttom UI
        else if(other.CompareTag("NPC")){
            press.SetActive(true);
        }
        if(other.CompareTag("Apple")){
            press.SetActive(true);
            LastItem = 1;
        }
        else if(other.CompareTag("Flower")){
            press.SetActive(true);
            LastItem = 2;
        }
        else if(other.CompareTag("Cow")){
            press.SetActive(true);
            LastItem = 3;
        }
        else if(other.CompareTag("Cat")){
            press.SetActive(true);
            LastItem = 4;
        }
        
            
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        //Hide "E" buttom UI
        if(other.CompareTag("NPC")){
            press.SetActive(false);
        }
         else if(other.CompareTag("Apple")){
           press.SetActive(false);
        }
        else if(other.CompareTag("Flower")){
            press.SetActive(false);
        }
        else if(other.CompareTag("Cow")){
           press.SetActive(false);
        }
        else if(other.CompareTag("Cat")){
           press.SetActive(false);
        }
            
    }
    public float Pouch(){
        //For Coins count
        return Money;
    }
    public float Mission(){
        //Paas what item the player has
        return MissionID;
    }
    public void Debit(){
        //Money draw
        if(Money >= 10){
            Money -= 10;
        }  
    }
    public void Complete()
    {
        //Money earned
        Money += 5;
        MissionID = 0;
        LastItem = 0;
    }
}
