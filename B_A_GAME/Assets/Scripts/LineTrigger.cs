using UnityEngine;

public class LineTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Skeletor")
        {
            if (gameObject.name == "FinishLine")
            {
                gameManager.ShowVictoryScreen();
            }
            else if (gameObject.name == "StartLine")
            {
                gameManager.StartGame();
            }
        }
    }
}
