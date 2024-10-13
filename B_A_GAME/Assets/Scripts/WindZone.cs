using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float windStrength = 10f; // ���� �����
    private Vector3 windDirection; // ����������� �����

    private void Start()
    {
        ChangeWindDirection();
        InvokeRepeating("ChangeWindDirection", 0f, 2f); // �������� ����������� ������ 2 �������
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // ��������, ��� ��� �����
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(windDirection * windStrength); // ���������� ���� �����
            }
        }
    }

    private void ChangeWindDirection()
    {
        // ��������� ���������� ����������� �� ��������� XZ
        float randomAngle = Random.Range(0f, 360f);
        windDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
    }
}
