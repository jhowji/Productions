using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Config : MonoBehaviour
{
    //Menu incial, Configurações e Pós-jogo
    public GameObject Menu;
    public GameObject Settings;
    public GameObject GameOver;
    //Timer
    public GameObject Countdown;
    public float TimeLeft = 59;
    private bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;
    public static float LastTimer = 59;
    //Respawn
    public float RespawnTime = 0;
    public TextMeshProUGUI Respawn;
    

    private void Start() {
        //Escondendo UI de configurações e timer
        GameOver.SetActive (false);
        Settings.SetActive (false);
        Countdown.SetActive (false);
        //Certificando que tudo esta pausado e setado
        Time.timeScale = 0;
        TimerOn = false;
        TimeLeft = LastTimer;
        updateTimer(TimeLeft);
        if(LastTimer > 300){
            //Pulando menu
            LastTimer = LastTimer - 300;
            TimeLeft = LastTimer;
            GameStart();
        }
        
    }
    void Update()
    {
        if(TimerOn)
        {
            //Condições contador
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                //tela de fim de jogo
                ItsOver();
                TimeLeft = 0;
                TimerOn = false;
            }
        }
        
    }

    void updateTimer(float currentTime)
    {
        //Contador em formato de minutos
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("Tempo {0:00}:{1:00}", minutes, seconds);
        Respawn.text = "Segundos morto: " + RespawnTime.ToString();
        
    }

    public void Exit()
    {
        Application.Quit(); //Sair do jogo
    }
    public void GameStart()
    {
        //Tirando menu e começando o jogo
        Menu.SetActive (false);
        Settings.SetActive (false);
        Countdown.SetActive (true);
        Time.timeScale = 1;
        TimerOn = true;
    }
    public void Increase()
    {
        //Modificar timer
        if(TimeLeft < 179){
            TimeLeft = TimeLeft + 60;
        }
        else{
            TimeLeft = 59;
        }
        LastTimer = TimeLeft;
        updateTimer(TimeLeft);
    }
    public void DeathTime()
    {
        //Modificar Respawn
        if(RespawnTime < 5){
            RespawnTime = RespawnTime + 1;
        }
        else{
            RespawnTime = 1;
        }
        Respawn.text = "Segundos morto: " + RespawnTime.ToString();
    }
    public void ChangeConfig()
    {
        //Mostrando apenas Configurações
        Settings.SetActive (true);
        Countdown.SetActive (true);
    }
    public void ItsOver()
    {
        //Tela pós-jogo
        GameOver.SetActive (true);
        Time.timeScale = 0;
    }
    public void Back()
    {
        //Escondendo configurações
        Settings.SetActive (false);
        Countdown.SetActive (false);
        Time.timeScale = 0;
    }
    public void Replay()
    {    
        //Jogar denovo
        LastTimer = LastTimer + 300;
        SceneManager.LoadScene("Game");
        
    }
    public void MainMenu()
    {
        //Voltar ao menu
        LastTimer = 59;
        SceneManager.LoadScene("Game");
    }
}