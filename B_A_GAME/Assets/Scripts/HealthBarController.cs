
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ResetHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void ResetHealthBar()
    {
        healthBar.color = Color.white; // Устанавливаем цвет полоски здоровья в белый
    }
}