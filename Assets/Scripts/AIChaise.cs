using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Animator animator;

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance < 10f)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;

            // Determine if the player is to the left or right of the enemy
            if (direction.x < 0)
            {
                // Play animation for moving left
                animator.SetBool("MovingLeft", true);
                animator.SetBool("MovingRight", false);
            }
            else
            {
                // Play animation for moving right
                animator.SetBool("MovingRight", true);
                animator.SetBool("MovingLeft", false);
            }
        }
        else
        {
            // Stop both animations when the enemy is not moving
            animator.SetBool("MovingLeft", false);
            animator.SetBool("MovingRight", false);
        }
    }
}
