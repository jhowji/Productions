using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRange : MonoBehaviour
{
    //Spawn
    public Transform firePoint; 
    public Transform firePointR1; 
    public Transform firePointR2; 
    public Transform firePointR3; 
    public Transform firePointL1; 
    public Transform firePointL2; 
    public Transform firePointL3;
    //Prefab
    public GameObject bulletPre; 
    public GameObject bulletPre2;
    public GameObject bulletPre3;
    //Velocidade da bala e direção
    public float bulletForce = 20f;
    //Fisica 
    public Collider2D me;
    private Rigidbody2D rb2;
    
    
    void Start() 
    {
        rb2 = this.GetComponent<Rigidbody2D>();
    }
    void Update() {
        rb2.position = firePoint.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Shoot();
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void Shoot()
    {
        //Cordenadas da bala e força do disparo
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        //proximo lado
        Invoke("ShootRight",1);
    }
    void ShootRight()
    {
        //Cordenadas das 3 balas
        GameObject bullet = Instantiate(bulletPre, firePointR1.position, firePointR1.rotation);
        GameObject bullet2 = Instantiate(bulletPre2, firePointR2.position, firePointR2.rotation); // segunda bala
        GameObject bullet3 = Instantiate(bulletPre3, firePointR3.position, firePointR3.rotation); // terceira bala
        Rigidbody2D rb1 = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        //Força de disparo das 3 balas
        rb1.AddForce(firePointR1.right * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePointR2.right * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePointR3.right * bulletForce, ForceMode2D.Impulse);
        Invoke("ShootLeft",1); //proximo lado
    }
    void ShootLeft()
    {
        //Cordenadas das 3 balas
        GameObject bullet = Instantiate(bulletPre, firePointL1.position, firePointL1.rotation);
        GameObject bullet2 = Instantiate(bulletPre2, firePointL2.position, firePointL2.rotation); // segunda bala
        GameObject bullet3 = Instantiate(bulletPre3, firePointL3.position, firePointL3.rotation); // terceira bala
        Rigidbody2D rb1 = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        //Força de disparo das 3 balas
        rb1.AddForce(firePointL1.right * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePointL2.right * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePointL3.right * bulletForce, ForceMode2D.Impulse);
        //reativa o radar
        Invoke("NewRadar",2);
    }
    void NewRadar()
    {
        GetComponent<Collider2D>().enabled = true;
    }

}
