using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Slider slider;
    //Valor inicial de vida
    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //Valor atual de vida
    public void HealthValue(int health)
    {
        slider.value = health;
    }

}
