using UnityEngine;
using UnityEngine.UI;

// Manage HUD elements: health, stamina, minimap (placeholder)
public class HUDController : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;
    public GameObject miniMap;
    public PlayerHealth playerHealth;
    public float maxStamina = 100f;
    public float currentStamina;

    void Awake()
    {
        currentStamina = maxStamina;
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth;
            healthSlider.value = playerHealth.currentHealth;
        }
    }

    void Update()
    {
        if (playerHealth != null && healthSlider != null)
            healthSlider.value = playerHealth.currentHealth;

        // Simple stamina regen placeholder
        currentStamina = Mathf.Clamp(currentStamina + 10f * Time.deltaTime, 0f, maxStamina);
        if (staminaSlider != null) staminaSlider.value = currentStamina;
    }

    public void ToggleMiniMap(bool show)
    {
        if (miniMap != null) miniMap.SetActive(show);
    }
}
