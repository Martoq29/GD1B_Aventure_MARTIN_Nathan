using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody2D rb;
    protected Vector2 direction;

    float SpeedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    public float maxHealth = 100f;
    float currentHealth;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth; // Initialiser la santé actuelle à la santé maximale au début
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= SpeedLimiter;
                inputVertical *= SpeedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Logique pour gérer la mort du joueur
        Debug.Log("Player died!");
        // D'autres actions comme le respawn du joueur peuvent être ajoutées ici
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Loot")) // Vérifie si l'objet en collision est du loot
        {
            CollectLoot(other.gameObject);
        }
    }

    // Fonction pour collecter le loot
    void CollectLoot(GameObject lootObject)
    {
        // Vous pouvez ajouter ici la logique pour traiter le loot collecté
        Debug.Log("Loot collected!");

        // Détruire le GameObject du loot
        Destroy(lootObject);
    }

}
