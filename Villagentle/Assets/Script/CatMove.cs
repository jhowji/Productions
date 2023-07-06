using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Rigidbody2D rb2;
    private float Speed = 10f;
    private int Crono = 0;
    private SpriteRenderer spriteRenderer;
    Vector2 Movement;
    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Crono += 1;
        //timer for the cat change walking direction
        if(Crono > 600){
            Crono = 0;
        }
        else  if(Crono > 300 ){
            Movement.x = 1;
            spriteRenderer.flipX = true;
        }
        else if(Crono < 300){
             Movement.x = -1;
             spriteRenderer.flipX = false;
        }
        
        rb2.MovePosition(rb2.position + Movement * Speed * Time.fixedDeltaTime);
    }
}
