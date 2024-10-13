using UnityEngine;

public class SpikeBallDamage : MonoBehaviour
{
    public float damageAmount = 1f / 3f; // ����, ��������� ������
    private HealthManager healthManager;

    private void Start()
    {
        // ����� GameObject � ����������� HealthManager � �������� ������ �� ����
        GameObject skeletorObject = GameObject.Find("Skeletor");
        healthManager = skeletorObject.GetComponent<HealthManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ���������� �� ��� � ������� (Skeletor)
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��������� �������� ������ �� damageAmount
            healthManager.TakeDamage(damageAmount);
        }
    }
}
