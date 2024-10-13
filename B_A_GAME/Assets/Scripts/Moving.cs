using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���� ����������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ����������� ���������
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime);

        // ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // ��������, ����� �� �������� �� �����
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
