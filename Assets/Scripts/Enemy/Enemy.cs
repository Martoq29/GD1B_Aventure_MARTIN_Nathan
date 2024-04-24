using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Damageable
{
    [SerializeField] public float maxHealth = 5f;

    private Transform target;

    private float currentHealth;
    [Header("Loot")]
    public List<Loot> lootTable = new List<Loot>();

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        

    }

    void InstantiateLoot(GameObject loot)
    {
        GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity);

        droppedLoot.GetComponent<SpriteRenderer>().color = Color.red;
    }

}