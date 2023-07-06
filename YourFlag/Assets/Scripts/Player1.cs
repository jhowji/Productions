using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player1 : MonoBehaviour
{
    //Fisicas
    private float Speed = 4;
    public float rotationSpeed;
    private Rigidbody2D rb2;
    public Collider2D coll;
    Vector2 Movement;

    //public Animator anim;
    public static Player1 instance;
    public float points;

    //UI
    public TextMeshProUGUI pointsText;
    public Life health;

    //Vida maxima e vida atual
    private int fullLife = 6;
    private int ActualLife;

    //Sprites e animações
    public Sprite[] navyBody;

    //Audio
    public AudioSource bump;
    public AudioSource impact;

    void Start(){
        ActualLife = fullLife;
        health.HealthValue(fullLife);
        coll = GetComponent<Collider2D>();
        rb2 = this.GetComponent<Rigidbody2D>();
        points = 0;
        SetPoints();
    }
    void Update()
    {
        //Input de movimentação
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(Movement.x, Movement.y);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * Speed * inputMagnitude * Time.deltaTime, Space.World);

        //Rotação do navio ao trocar de direção
        if(movementDirection != Vector2.zero){
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


    }
    //Interações com outros objetos
     public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Finish")){
            points -= 3;
            SetDamage(6);
            SetPoints();
            impact.Play();
        }
            
    }
    private void OnCollisionEnter2D(Collision2D other) 
    { 
        SetDamage(1);
        points = points - 1;
        SetPoints();
        bump.Play();
    }

    //Contagem de pontos
    public void SetPoints()
    {
        pointsText.text = "Pontos: " + points.ToString();
    }
    //dano na barra de vida
    public void SetDamage(int damage)
    {
        ActualLife -= damage;
        //troca de sprite
        if(ActualLife == 4 || ActualLife == 3){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = navyBody[1];
        }
        else if(ActualLife == 2 || ActualLife == 1){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = navyBody[2];
        }
        else if(ActualLife < 1){
            //penalidade por barra de vida vazia
            this.gameObject.GetComponent<SpriteRenderer>().sprite = navyBody[3];
            points -= 3;
            GetComponent<Collider2D>().enabled = false;
            Speed = 0;
            Invoke("GhostShip",1);
        }
        health.HealthValue(ActualLife);
    }
    public void GhostShip()
    {
        Speed = 4;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = navyBody[0];
        ActualLife = 6;
        SetDamage(0);
        GetComponent<Collider2D>().enabled = true;
    }
}
