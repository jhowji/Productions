using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //efeito de explosão
    public GameObject hitEffect;
    //Audio
    public AudioSource shooting;
    public AudioSource impact;

    private void Start() {
        shooting.Play();
    }
    //Animação ao colidir
     private void OnCollisionEnter2D(Collision2D other) 
    { 
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        impact.Play();
        Destroy(effect, 3f);
        Destroy(gameObject,3f);
        
    }
}
