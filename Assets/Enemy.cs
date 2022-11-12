using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 50f;

    public GameObject parent;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(parent);
    }
}
