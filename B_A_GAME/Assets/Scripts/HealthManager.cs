using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 3f; // Максимальное здоровье
    private float currentHealth; // Текущее здоровье
    private Image healthBar; // Ссылка на элемент полосы здоровья
    private Rigidbody rb; // Ссылка на Rigidbody игрока
    private GameOverManager gameOverManager; // Ссылка на GameOverManager


    private void Start()
    {
        // Найдите GameObject с изображением полосы здоровья и получите ссылку на него
        GameObject healthBarObject = GameObject.Find("HealthBar");
        healthBar = healthBarObject.GetComponent<Image>();

        // Получите ссылку на Rigidbody игрока
        rb = GetComponent<Rigidbody>();

        // Получите ссылку на GameOverManager
        gameOverManager = FindObjectOfType<GameOverManager>();

        // Установите начальное здоровье на максимальное
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        // Уменьшите текущее здоровье на 1/3 от максимального
        currentHealth -= maxHealth * 0.33f;

        // Обновите визуальное представление полосы здоровья
        UpdateHealthBar();

        // Если здоровье опустилось до 0 или ниже, убейте персонажа
        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Knockback(Vector3 direction, float force)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * force);
        }
    }
    public void SetHealthToZero()
    {
        // Установите здоровье в 0, чтобы полоса стала полностью белой
        currentHealth = 0;
        UpdateHealthBar();
    }

    private void Kill()
    {
        // Реализуйте логику для уничтожения персонажа
        Debug.Log("Игрок умер");
        gameOverManager.ShowGameOver(); // Показываем экран "Поражение!"
    }

    private void UpdateHealthBar()
    {
        // Обновите размер зеленой полосы здоровья в соответствии с текущим здоровьем
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void FixedUpdate()
    {
        // Проверяем, падает ли игрок
        if (rb.velocity.y < -7f) // Вы можете настроить этот порог скорости по своему усмотрению
        {
            // Если да, то немедленно убиваем персонажа
            SetHealthToZero();
        }
    }
}