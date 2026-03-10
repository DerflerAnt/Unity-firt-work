using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 120.0f;
    public float jumpForce = 5.0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 4. Стрибок (пробіл)
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        // 1. Отримуємо введення від гравця (W/S або стрілочки)
        float moveVertical = Input.GetAxis("Vertical");

        // 2. ПЕРЕВІРКА ПЕРЕШКОД (Raycast)
        // Створюємо промінь, щоб зрозуміти, чи є попереду стіна
        bool hitWall = Physics.Raycast(transform.position + Vector3.up * 0.2f, transform.forward, 0.6f);

        // Дозволяємо рух вперед ТІЛЬКИ якщо попереду немає стіни АБО якщо ми їдемо назад
        if (!hitWall || moveVertical < 0)
        {
            Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }

        // 3. ПОВОРОТ (A/D або стрілочки)
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}