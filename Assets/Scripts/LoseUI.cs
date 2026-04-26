using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    public GameObject losePanel;

    public void Show()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f; // pause game
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}