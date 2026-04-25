using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        int savedLevel = PlayerPrefs.GetInt("Level", 1);
        SceneManager.LoadScene(savedLevel);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("Level");
        Debug.Log("Progress Reset");
    }
}