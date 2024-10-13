using System.Collections;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public float damageAmount = 1f / 3f; // Устанавливаем, что игрок теряет 1/3 здоровья
    public int maxCollisions = 3; // Устанавливаем, что после 3 столкновений игрок умирает

    private int currentCollisions = 0;
    private HealthManager healthManager;
    public bool isPlatformActive = false;

    private void Start()
    {
        // Найдите GameObject с компонентом HealthManager и получите ссылку на него
        GameObject healthManagerObject = GameObject.Find("Skeletor");
        healthManager = healthManagerObject.GetComponent<HealthManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Skeletor")
        {
            if (!isPlatformActive)
            {
                // Платформа активирована, обновите ее цвет на оранжевый
                GetComponent<Renderer>().material.color = new Color32(255, 165, 0, 255);

                isPlatformActive = true;

                // Запустите корутину для нанесения урона через 1 секунду
                StartCoroutine(DamagePlayerAfterDelay(1f));
            }
        }
    }

    IEnumerator DamagePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Уменьшаем здоровье игрока на damageAmount
        healthManager.TakeDamage(damageAmount);

        // Увеличиваем счетчик столкновений
        currentCollisions++;

        // Обновите цвет платформы на красный
        GetComponent<Renderer>().material.color = Color.red;

        // Запустите корутину для перехода платформы в исходное состояние через 1 секунду
        StartCoroutine(ResetPlatformState(1f));

        // Если количество столкновений достигло максимума, обнуляем здоровье игрока
        if (currentCollisions >= maxCollisions)
        {
            healthManager.SetHealthToZero();
        }
    }

    IEnumerator ResetPlatformState(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Обновите цвет платформы на исходный
        GetComponent<Renderer>().material.color = Color.white;

        // Сбросьте состояние платформы
        isPlatformActive = false;

        // Запустите корутину для перезарядки платформы через 5 секунд
        StartCoroutine(RechargeAndResetPlatform(5f));
    }

    IEnumerator RechargeAndResetPlatform(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Сбросьте все состояния платформы
        isPlatformActive = false;
        currentCollisions = 0;
        // Здесь можно добавить дополнительную логику для сброса платформы
    }
}