using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 200;

    private Animator anim;
    private int currentHealth;

    public HealthBar healthBar;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("IsHit");
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        anim.Play("Dead");
    }

}
