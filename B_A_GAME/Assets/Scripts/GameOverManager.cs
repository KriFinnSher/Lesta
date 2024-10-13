using UnityEngine;
using UnityEngine.SceneManagement; // Для перезагрузки сцены
using UnityEngine.UI; // Для работы с UI

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Ссылка на панель "Поражение!"

    private void Start()
    {
        // Изначально скрываем панель
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Показываем панель "Поражение!"
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагрузка текущей сцены
    }

    // Новый метод для обработки триггеров
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что столкновение произошло с объектом "DeathZone"
        if (other.gameObject.name == "Ground" || other.gameObject.name == "Skeletor")
        {
            ShowGameOver(); // Показываем экран "Поражение!"
        }
    }
}

