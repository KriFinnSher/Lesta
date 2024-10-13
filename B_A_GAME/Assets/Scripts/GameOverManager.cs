using UnityEngine;
using UnityEngine.SceneManagement; // ��� ������������ �����
using UnityEngine.UI; // ��� ������ � UI

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // ������ �� ������ "���������!"

    private void Start()
    {
        // ���������� �������� ������
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // ���������� ������ "���������!"
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������ ������� �����
    }

    // ����� ����� ��� ��������� ���������
    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������������ ��������� � �������� "DeathZone"
        if (other.gameObject.name == "Ground" || other.gameObject.name == "Skeletor")
        {
            ShowGameOver(); // ���������� ����� "���������!"
        }
    }
}

