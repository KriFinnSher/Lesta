using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float windStrength = 10f; // Сила ветра
    private Vector3 windDirection; // Направление ветра

    private void Start()
    {
        ChangeWindDirection();
        InvokeRepeating("ChangeWindDirection", 0f, 2f); // Изменять направление каждые 2 секунды
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Проверка, что это игрок
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(windDirection * windStrength); // Применение силы ветра
            }
        }
    }

    private void ChangeWindDirection()
    {
        // Генерация случайного направления на плоскости XZ
        float randomAngle = Random.Range(0f, 360f);
        windDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
    }
}
