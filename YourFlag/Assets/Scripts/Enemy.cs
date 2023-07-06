using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Fisica
    private Rigidbody2D rb2;
    public Collider2D coll;
    //Movimentação
    public Transform[] point;
    public int destination;
    private float speed = 3f;
    public float rotationSpeed;

    //Sprites e animações
    public Sprite[] enemyBody;

    //Tempo de Respawn
    public Config death;
    private float dead;

    //UI
    public Player1 player;
    public Life health;

    //Vida maxima e vida atual
    private int fullLife = 6;
    private int ActualLife;


    void Start()
    {
        ActualLife = fullLife;
        health.HealthValue(fullLife);
        coll = GetComponent<Collider2D>();
        rb2 = this.GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        //Caminho ao primeiro ponto
        if(destination == 0){
            transform.position = Vector2.MoveTowards(transform.position, point[0].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, point[0].position) < 0.3f)
            {
                //Vendo se ja completou uma volta e marcando proximo ponto
                if(rb2.rotation > 0){
                    
                    rb2.rotation += 90;
                }
                destination = 1;
            }
        }
        else if(destination == 1){
            transform.position = Vector2.MoveTowards(transform.position, point[1].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, point[1].position) < 0.3f)
            {
                //Rotacionando e marcando proximo ponto
                rb2.rotation += 90;
                destination = 2;
            }
        }
        if(destination == 2){
            transform.position = Vector2.MoveTowards(transform.position, point[2].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, point[2].position) < 0.3f)
            {
                //Rotacionando e marcando proximo ponto
                rb2.rotation += 90;
                destination = 3;
            }
        }
        if(destination == 3){
            transform.position = Vector2.MoveTowards(transform.position, point[3].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, point[3].position) < 0.3f)
            {
                //Rotacionando e marcando proximo ponto
                rb2.rotation += 90;
                destination = 0;
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ship")){
            Reward(1);
            SetDamage(1);
        }
        if(other.CompareTag("Player")){
            SetDamage(6);
        }
    }

    public void SetDamage(int damage)
    {
        dead = death.RespawnTime;
        ActualLife -= damage;
        if(ActualLife == 4 || ActualLife == 3){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyBody[1];
        }
        else if(ActualLife == 2 || ActualLife == 1){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyBody[2];
        }
        else if(ActualLife < 1){
            //Morto
            GetComponent<Collider2D>().enabled = false;
            Invoke("DeathTime",death.RespawnTime);
            speed = 0;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyBody[3]; 
            //recompensa
            Reward(2);         
        }
        health.HealthValue(ActualLife);
    }
    public void Reward(int shot)
    {
        //Pontos por ser acertado
        player.points += shot;
        player.SetPoints();
    }
    public void DeathTime(){
        speed = 3;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyBody[0];
        ActualLife = 6;
        GetComponent<Collider2D>().enabled = true;
        SetDamage(0);
    }
}
