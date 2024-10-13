using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    public float jumpForce = 5f; // Сила прыжка
    public Transform groundCheck; // Объект для проверки, находится ли игрок на земле
    public LayerMask groundLayer; // Слой земли
    private Rigidbody rb; // Ссылка на Rigidbody игрока
    private bool isGrounded; // Флаг, указывающий, находится ли игрок на земле

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Проверяем, находимся ли мы на земле
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Получаем входные данные для движения
        float moveInput = Input.GetAxis("Horizontal"); // Влево/вправо
        Vector3 moveDirection = new Vector3(moveInput, 0, 0).normalized;

        // Движение игрока
        MovePlayer(moveDirection);

        // Проверка на прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        // Если игрок движется, поворачиваем его в сторону движения
        if (direction != Vector3.zero)
        {
            // Поворачиваем игрока по направлению движения
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Перемещение игрока
        Vector3 move = direction * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void Jump()
    {
        // Применяем силу прыжка
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        // Если игрок перевернулся, возвращаем его в вертикальное положение
        if (transform.up.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
