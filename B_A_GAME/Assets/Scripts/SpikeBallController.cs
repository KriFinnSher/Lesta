using UnityEngine;

public class SpikeBallController : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ����
    private Rigidbody rb;
    private Vector3 direction;
    private float timeUntilDirectionChange = 1f; // ����� �� ����� ����������� �������� (� ��������)

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ���������� ��������� �������������� ����������� ��������
        SetRandomHorizontalDirection();
    }

    private void FixedUpdate()
    {
        MoveAndReflectFromWalls();
        ChangeDirectionIfNeeded();
    }

    private void MoveAndReflectFromWalls()
    {
        // �������� ���� � ��������� �� ������
        RaycastHit hit;

        // ��������� ������������ � ����� ������
        if (Physics.Raycast(transform.position, -transform.right, out hit, Mathf.Abs(direction.x) * Time.fixedDeltaTime))
        {
            // �������� ��� �� ����� �����
            direction = Vector3.Reflect(direction, -transform.right);
        }
        // ��������� ������������ � ������ ������
        else if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Abs(direction.x) * Time.fixedDeltaTime))
        {
            // �������� ��� �� ������ �����
            direction = Vector3.Reflect(direction, transform.right);
        }

        // ���������� �������������� �������� ����
        rb.velocity = new Vector3(direction.x * speed, 0f, 0f);
        transform.position += new Vector3(direction.x * speed, 0f, 0f) * Time.fixedDeltaTime;
    }

    private void ChangeDirectionIfNeeded()
    {
        // ��������� ����� �� ����� �����������
        timeUntilDirectionChange -= Time.fixedDeltaTime;

        // ���� ����� �����, ���������� ����� ��������� �������������� �����������
        if (timeUntilDirectionChange <= 0f)
        {
            SetRandomHorizontalDirection();
            timeUntilDirectionChange = 1f; // �������� ����� �� ��������� ����� �����������
        }
    }

    private void SetRandomHorizontalDirection()
    {
        // ���������� ��������� �������������� ����������� ��������
        direction = new Vector3(Random.Range(-1f, 1f), 0f, 0f).normalized;
    }
}
