using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] norPros;

    private Animator anim;
    private SlimeController playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<SlimeController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.C) && cooldownTimer > attackCooldown && playerMovement.canAttack()
            && Time.timeScale > 0)
            Attack();
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        //SoundManager.instance.PlaySound(norProsound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        norPros[FindFireball()].transform.position = firePoint.position;
        norPros[FindFireball()].GetComponent<NormalProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));

        //playerMovement.mana -= 1;
    }
    private int FindFireball()
    {
        for (int i = 0; i < norPros.Length; i++)
        {
            if (!norPros[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
