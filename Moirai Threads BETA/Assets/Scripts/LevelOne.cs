using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{
    public string Game;
    public int level;
    public string nomeDaCena;
    public string nextLevel;
    public string vitoria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -150)
        {
            SceneManager.LoadScene(Game);
        }
    }
    void OnCollisionEnter (Collision col) 
    {
        if(col.gameObject.tag == "pilar")
        {
            level = 1;
        }
        else if(col.gameObject.tag == "pilar2" )
        {
            if(level == 1){
                level = 2;
            }
            
        }
        else if(col.gameObject.tag == "pilar3" )
        {
            if(level == 2){
                level = 3;
            }
            
        }
        else if(col.gameObject.tag == "pilar4" )
        {
            if(level == 3){
                level = 4;
            }
            
        }
        else if(col.gameObject.tag == "Finish" )
        {
            if(level < 4){
            SceneManager.LoadScene(nomeDaCena);
            Debug.Log("Que pena, tente novamente");
            }
            if(level == 4){
            SceneManager.LoadScene(vitoria);
            Debug.Log("Você Venceu");
            }
           
        }
        else if(col.gameObject.tag == "Respawn" )
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
