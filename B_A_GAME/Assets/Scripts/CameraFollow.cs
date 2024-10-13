using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ Skeletor
    public float smoothSpeed = 0.125f; // Скорость плавного перемещения
    public Vector3 offset; // Смещение камеры относительно Skeletor

    private void LateUpdate()
    {
        // Вычисляем желаемую позицию камеры
        Vector3 desiredPosition = target.position + offset;

        // Плавно перемещаем камеру к желаемой позиции
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Поворачиваем камеру, чтобы смотреть на Skeletor
        transform.LookAt(target);
    }
}
