using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Кількість реальних секунд, за які проходить один повний ігровий день.")]
    public float dayDurationInSeconds = 120f;

    void Update()
    {
        // Перевірка, щоб уникнути помилки ділення на нуль
        if (dayDurationInSeconds > 0)
        {
            // Вираховуємо швидкість: 360 градусів (повний оберт) ділимо на кількість секунд
            float rotationSpeed = 360f / dayDurationInSeconds;

            // Обертаємо джерело світла по осі X для імітації руху сонця
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}