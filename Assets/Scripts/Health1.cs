using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class Health1 : MonoBehaviour
{
    //[SerializeField] private float startingHealth;
    float startingHealth=5;
    //private currentHealth;
    float currentHealth;
    public Image[] healthPoints;

    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    private void Awake()
    {
        currentHealth=startingHealth;
    }
    private void Update() 
    {
        if (currentHealth>startingHealth) currentHealth=startingHealth;
        HealthBarFiller();
    }
    public void TakeDamage(float _damage)
    {
        //currentHealth =Mathf.Clamp(currentHealth- _damage, 0, startingHealth);
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            //SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
                //SoundManager.instance.PlaySound(deathSound);
            }
        }
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
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
