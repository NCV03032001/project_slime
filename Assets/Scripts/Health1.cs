using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class Healthbar1 : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    //[SerializeField] private float startingHealth;
    //float startingHealth=5;
    //private currentHealth;
    //float currentHealth;
    public Image[] healthPoints;


    private void Update() 
    {
        HealthBarFiller();
    }
   
    void HealthBarFiller()
    {
        for (int i=0; i< healthPoints.Length;i++)
        {
            healthPoints[i].enabled=!DisplayHealthPoint(playerHealth.currentHealth, i);
        }
    }   
    bool DisplayHealthPoint(float _currentHealth, int pointNumber)
    {
        return (((pointNumber)) >= _currentHealth);
    }
}
