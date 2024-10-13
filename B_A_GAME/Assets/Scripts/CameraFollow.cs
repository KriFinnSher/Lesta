using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ������ �� ��������� Skeletor
    public float smoothSpeed = 0.125f; // �������� �������� �����������
    public Vector3 offset; // �������� ������ ������������ Skeletor

    private void LateUpdate()
    {
        // ��������� �������� ������� ������
        Vector3 desiredPosition = target.position + offset;

        // ������ ���������� ������ � �������� �������
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ������������ ������, ����� �������� �� Skeletor
        transform.LookAt(target);
    }
}
