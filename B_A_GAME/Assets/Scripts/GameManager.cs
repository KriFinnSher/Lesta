using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject victoryCanvas;
    public Text victoryText;
    public Text timeText;
    public Button restartButton;

    private float startTime;
    private bool isGameActive = false;

    void Start()
    {
        victoryCanvas.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (isGameActive)
        {
            float timeElapsed = Time.time - startTime;
            timeText.text = "Время : " + timeElapsed.ToString("F2") + " секунд"; // Обновляем текст времени
        }
    }

    public void StartGame()
    {
        startTime = Time.time;
        isGameActive = true;
        timeText.text = "Время : 0 секунд"; // Сброс текста времени
    }

    public void ShowVictoryScreen()
    {
        isGameActive = false;
        Time.timeScale = 0; // Пауза
        float finalTime = Time.time - startTime;
        timeText.text = "Время : " + finalTime.ToString("F2") + " секунд"; // Показываем итоговое время
        victoryCanvas.SetActive(true);
    }

    private void RestartGame()
    {
        Time.timeScale = 1; // Снять паузу
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}