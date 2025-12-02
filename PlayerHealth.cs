using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // TODO: Hook up UI update, death, etc.
        if (currentHealth <= 0)
        {
            Debug.Log("Player died - implement respawn or game over.");   
        }
    }
}
