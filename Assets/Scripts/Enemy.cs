using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Animator anim;

    public bool enemyIsDead;

    public HealthBar healthBar;

    public GameObject healthBarObject;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Invoke("SetHealthBar", 0.3f);

        anim.SetTrigger("Hurt");

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
        healthBarObject.SetActive(false);

        this.enabled = false;
        Debug.Log("Enemy died!");
    }

    private void SetHealthBar()
    {
        healthBar.SetHealth(currentHealth);
    }
}
