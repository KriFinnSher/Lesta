using UnityEngine;

public class SpikeBallDamage : MonoBehaviour
{
    public float damageAmount = 1f / 3f; // Урон, наносимый игроку
    private HealthManager healthManager;

    private void Start()
    {
        // Найти GameObject с компонентом HealthManager и получить ссылку на него
        GameObject skeletorObject = GameObject.Find("Skeletor");
        healthManager = skeletorObject.GetComponent<HealthManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверить, столкнулся ли шар с игроком (Skeletor)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Уменьшить здоровье игрока на damageAmount
            healthManager.TakeDamage(damageAmount);
        }
    }
}
