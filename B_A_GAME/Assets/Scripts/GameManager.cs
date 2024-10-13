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
            timeText.text = "����� : " + timeElapsed.ToString("F2") + " ������"; // ��������� ����� �������
        }
    }

    public void StartGame()
    {
        startTime = Time.time;
        isGameActive = true;
        timeText.text = "����� : 0 ������"; // ����� ������ �������
    }

    public void ShowVictoryScreen()
    {
        isGameActive = false;
        Time.timeScale = 0; // �����
        float finalTime = Time.time - startTime;
        timeText.text = "����� : " + finalTime.ToString("F2") + " ������"; // ���������� �������� �����
        victoryCanvas.SetActive(true);
    }

    private void RestartGame()
    {
        Time.timeScale = 1; // ����� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}