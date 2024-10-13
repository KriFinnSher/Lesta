using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 3f; // ������������ ��������
    private float currentHealth; // ������� ��������
    private Image healthBar; // ������ �� ������� ������ ��������
    private Rigidbody rb; // ������ �� Rigidbody ������
    private GameOverManager gameOverManager; // ������ �� GameOverManager


    private void Start()
    {
        // ������� GameObject � ������������ ������ �������� � �������� ������ �� ����
        GameObject healthBarObject = GameObject.Find("HealthBar");
        healthBar = healthBarObject.GetComponent<Image>();

        // �������� ������ �� Rigidbody ������
        rb = GetComponent<Rigidbody>();

        // �������� ������ �� GameOverManager
        gameOverManager = FindObjectOfType<GameOverManager>();

        // ���������� ��������� �������� �� ������������
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        // ��������� ������� �������� �� 1/3 �� �������������
        currentHealth -= maxHealth * 0.33f;

        // �������� ���������� ������������� ������ ��������
        UpdateHealthBar();

        // ���� �������� ���������� �� 0 ��� ����, ������ ���������
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
        // ���������� �������� � 0, ����� ������ ����� ��������� �����
        currentHealth = 0;
        UpdateHealthBar();
    }

    private void Kill()
    {
        // ���������� ������ ��� ����������� ���������
        Debug.Log("����� ����");
        gameOverManager.ShowGameOver(); // ���������� ����� "���������!"
    }

    private void UpdateHealthBar()
    {
        // �������� ������ ������� ������ �������� � ������������ � ������� ���������
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void FixedUpdate()
    {
        // ���������, ������ �� �����
        if (rb.velocity.y < -7f) // �� ������ ��������� ���� ����� �������� �� ������ ����������
        {
            // ���� ��, �� ���������� ������� ���������
            SetHealthToZero();
        }
    }
}