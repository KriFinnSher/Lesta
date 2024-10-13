using System.Collections;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public float damageAmount = 1f / 3f; // �������������, ��� ����� ������ 1/3 ��������
    public int maxCollisions = 3; // �������������, ��� ����� 3 ������������ ����� �������

    private int currentCollisions = 0;
    private HealthManager healthManager;
    public bool isPlatformActive = false;

    private void Start()
    {
        // ������� GameObject � ����������� HealthManager � �������� ������ �� ����
        GameObject healthManagerObject = GameObject.Find("Skeletor");
        healthManager = healthManagerObject.GetComponent<HealthManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Skeletor")
        {
            if (!isPlatformActive)
            {
                // ��������� ������������, �������� �� ���� �� ���������
                GetComponent<Renderer>().material.color = new Color32(255, 165, 0, 255);

                isPlatformActive = true;

                // ��������� �������� ��� ��������� ����� ����� 1 �������
                StartCoroutine(DamagePlayerAfterDelay(1f));
            }
        }
    }

    IEnumerator DamagePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // ��������� �������� ������ �� damageAmount
        healthManager.TakeDamage(damageAmount);

        // ����������� ������� ������������
        currentCollisions++;

        // �������� ���� ��������� �� �������
        GetComponent<Renderer>().material.color = Color.red;

        // ��������� �������� ��� �������� ��������� � �������� ��������� ����� 1 �������
        StartCoroutine(ResetPlatformState(1f));

        // ���� ���������� ������������ �������� ���������, �������� �������� ������
        if (currentCollisions >= maxCollisions)
        {
            healthManager.SetHealthToZero();
        }
    }

    IEnumerator ResetPlatformState(float delay)
    {
        yield return new WaitForSeconds(delay);

        // �������� ���� ��������� �� ��������
        GetComponent<Renderer>().material.color = Color.white;

        // �������� ��������� ���������
        isPlatformActive = false;

        // ��������� �������� ��� ����������� ��������� ����� 5 ������
        StartCoroutine(RechargeAndResetPlatform(5f));
    }

    IEnumerator RechargeAndResetPlatform(float delay)
    {
        yield return new WaitForSeconds(delay);

        // �������� ��� ��������� ���������
        isPlatformActive = false;
        currentCollisions = 0;
        // ����� ����� �������� �������������� ������ ��� ������ ���������
    }
}