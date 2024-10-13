using UnityEngine;

public class CylinderManager : MonoBehaviour
{
    public float launchForce = 500f; // ���� ������������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Skeletor")
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                // ���������� ����������� ������������
                Vector3 direction = other.transform.position - transform.position;
                direction.Normalize(); // ����������� ������
                direction.y = 0; // ������� ������������ ������������
                healthManager.Knockback(direction, launchForce); // ����������� ������
            }
        }
    }
}
