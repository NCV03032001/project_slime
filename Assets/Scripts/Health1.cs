using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health1 : MonoBehaviour
{
    //[SerializeField] private float startingHealth;
    float startingHealth=5;
    //private currentHealth;
    float currentHealth;
    public Image[] healthPoints;

    private void Awake()
    {
        currentHealth=startingHealth;
    }
    private void Update() 
    {
        if (currentHealth>startingHealth) currentHealth=startingHealth;
        HealthBarFiller();
    }
    public void TakeDamage1(float _damage)
    {
        //currentHealth =Mathf.Clamp(currentHealth- _damage, 0, startingHealth);
    }
    void HealthBarFiller()
    {
        for (int i=0; i< healthPoints.Length;i++)
        {
            healthPoints[i].enabled=!DisplayHealthPoint(currentHealth, i);
        }
    }
    bool DisplayHealthPoint(float _currentHealth, int pointNumber)
    {
        return (((pointNumber)) >= _currentHealth);
    }
}
