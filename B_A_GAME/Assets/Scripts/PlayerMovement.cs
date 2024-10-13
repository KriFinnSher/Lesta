using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ��������
    public float jumpForce = 5f; // ���� ������
    public Transform groundCheck; // ������ ��� ��������, ��������� �� ����� �� �����
    public LayerMask groundLayer; // ���� �����
    private Rigidbody rb; // ������ �� Rigidbody ������
    private bool isGrounded; // ����, �����������, ��������� �� ����� �� �����

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ���������, ��������� �� �� �� �����
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // �������� ������� ������ ��� ��������
        float moveInput = Input.GetAxis("Horizontal"); // �����/������
        Vector3 moveDirection = new Vector3(moveInput, 0, 0).normalized;

        // �������� ������
        MovePlayer(moveDirection);

        // �������� �� ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        // ���� ����� ��������, ������������ ��� � ������� ��������
        if (direction != Vector3.zero)
        {
            // ������������ ������ �� ����������� ��������
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // ����������� ������
        Vector3 move = direction * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void Jump()
    {
        // ��������� ���� ������
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        // ���� ����� ������������, ���������� ��� � ������������ ���������
        if (transform.up.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
