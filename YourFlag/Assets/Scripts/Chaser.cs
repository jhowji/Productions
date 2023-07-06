using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    //Posição do jogador
    public Transform target;

    //Fisicas
    private float speed = 1f;
    private Rigidbody2D rb2;
    private Vector2 movement;
    private Collider2D coll;
    public Life health;

    //Posição e tempo de Respawn
    public Vector2 spawnBoat;
    public Config death;
    private float dead;

    //Vida maxima e vida atual
    private int fullLife = 2;
    private int ActualLife;

    //Sprites e animações
    public Animator anim;

    void Start()
    {
        ActualLife = fullLife;
        health.HealthValue(fullLife);
        rb2 = this.GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2.rotation = angle + 90;
        direction.Normalize();
        movement = direction;
        
    }
    private void FixedUpdate() {
        if(GetComponent<Collider2D>().enabled){
            targetPath(movement);
        }
        
    }
    
    void targetPath(Vector2 direction){
        rb2.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ship")){
            SetDamage(1);
        }
        if(other.CompareTag("Player")){
            SetDamage(2);
        }
    }

    public void SetDamage(int damage)
    {
        ActualLife -= damage;
        dead = death.RespawnTime;
        if(ActualLife == 1){
            anim.SetInteger("blows", 1);
        }
        if(ActualLife < 1){
            //Morto
            anim.SetInteger("blows", 2);
            GetComponent<Collider2D>().enabled = false;
            Invoke("DeathTime",dead);
        }
        health.HealthValue(ActualLife);
    }
    public void DeathTime(){
        ActualLife = 2;
        SetDamage(0);
        anim.SetInteger("blows", 0);
        transform.position = spawnBoat;
        GetComponent<Collider2D>().enabled = true;
    }
    
}
