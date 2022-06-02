using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Animator anim;
    private Rigidbody2D rb;

    public bool enemyIsDead;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Debug.Log(rb.velocity.x);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Invoke("TriggerHurtAnimation", 0.2f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        enemyIsDead = true;
        anim.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
        Debug.Log("Enemy died!");
    }

    private void TriggerHurtAnimation()
    {
        anim.SetTrigger("Hurt");
    }
}
