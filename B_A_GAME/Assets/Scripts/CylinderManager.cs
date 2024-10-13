using UnityEngine;

public class CylinderManager : MonoBehaviour
{
    public float launchForce = 500f; // Сила отталкивания

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Skeletor")
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                // Определяем направление отталкивания
                Vector3 direction = other.transform.position - transform.position;
                direction.Normalize(); // Нормализуем вектор
                direction.y = 0; // Убираем вертикальную составляющую
                healthManager.Knockback(direction, launchForce); // Отталкиваем игрока
            }
        }
    }
}
