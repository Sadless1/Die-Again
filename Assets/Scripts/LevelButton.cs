using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;

    public GameObject lockObj;
    public GameObject unlockObj;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (levelIndex <= LevelManager.unlockedLevel)
        {
            lockObj.SetActive(false);
            unlockObj.SetActive(true);
        }
        else
        {
            lockObj.SetActive(true);
            unlockObj.SetActive(false);
        }
    }

    public void LoadLevel()
    {
        if (levelIndex <= LevelManager.unlockedLevel)
        {
            SceneManager.LoadScene("Level " + levelIndex);
        }
    }
}