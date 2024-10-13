using UnityEngine;

public class SpikeBallController : MonoBehaviour
{
    public float speed = 5f; // —корость движени€ шара
    private Rigidbody rb;
    private Vector3 direction;
    private float timeUntilDirectionChange = 1f; // ¬рем€ до смены направлени€ движени€ (в секундах)

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ”становить начальное горизонтальное направление движени€
        SetRandomHorizontalDirection();
    }

    private void FixedUpdate()
    {
        MoveAndReflectFromWalls();
        ChangeDirectionIfNeeded();
    }

    private void MoveAndReflectFromWalls()
    {
        // ƒвижение шара и отражение от стенок
        RaycastHit hit;

        // ѕровер€ем столкновение с левой стеной
        if (Physics.Raycast(transform.position, -transform.right, out hit, Mathf.Abs(direction.x) * Time.fixedDeltaTime))
        {
            // ќтразить шар от левой стены
            direction = Vector3.Reflect(direction, -transform.right);
        }
        // ѕровер€ем столкновение с правой стеной
        else if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Abs(direction.x) * Time.fixedDeltaTime))
        {
            // ќтразить шар от правой стены
            direction = Vector3.Reflect(direction, transform.right);
        }

        // ѕродолжить горизонтальное движение шара
        rb.velocity = new Vector3(direction.x * speed, 0f, 0f);
        transform.position += new Vector3(direction.x * speed, 0f, 0f) * Time.fixedDeltaTime;
    }

    private void ChangeDirectionIfNeeded()
    {
        // ”меньшить врем€ до смены направлени€
        timeUntilDirectionChange -= Time.fixedDeltaTime;

        // ≈сли врем€ вышло, установить новое случайное горизонтальное направление
        if (timeUntilDirectionChange <= 0f)
        {
            SetRandomHorizontalDirection();
            timeUntilDirectionChange = 1f; // —бросить врем€ до следующей смены направлени€
        }
    }

    private void SetRandomHorizontalDirection()
    {
        // ”становить случайное горизонтальное направление движени€
        direction = new Vector3(Random.Range(-1f, 1f), 0f, 0f).normalized;
    }
}
