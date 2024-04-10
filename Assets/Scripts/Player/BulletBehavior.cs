using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroyBullet;
    [SerializeField] private float normalBulletDamage = 1f;

    private Rigidbody2D rb;
    private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();

        SetStraightVelocity();

        damage = normalBulletDamage; // Initialisation de la variable damage
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroyBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            Damageable damageable = collision.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Damage(damage);
            }

            Destroy(gameObject);
        }
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
