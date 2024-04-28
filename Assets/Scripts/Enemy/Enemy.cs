using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Damageable
{
    public float damageAmount = 10f;
    [SerializeField] public float maxHealth = 5f;

    private Transform target;

    private float currentHealth;
    [Header("Loot")]
    public List<Loot> lootTable = new List<Loot>();
    public PlayerHealth PlayerHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

        

    }

    void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }

    public LayerMask playerLayer; // Masque de collision pour le joueur

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet en collision est sur la couche du joueur
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            // Récupère le composant Player du GameObject en collision
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damageAmount); // Infliger des dégâts au joueur
            }

            // Ajoutez ici d'autres actions spécifiques à la collision avec le joueur
            // Par exemple, déclencher des animations, jouer des effets sonores, etc.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth.TakeDamage(1);
        }

        
    }


}