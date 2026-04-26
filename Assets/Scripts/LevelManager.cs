using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Lấy level hiện tại (index trong Build Settings)
    public int GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    // Lưu level đã mở khóa
    public void SaveProgress(int levelIndex)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelIndex > unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelIndex);
            PlayerPrefs.Save();
        }
    }

    // Load level tiếp theo
    public void LoadNextLevel()
    {
        int current = GetCurrentLevel();
        int nextLevel = current + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            SaveProgress(nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            // hết game → quay về Lobby hoặc LevelSelect
            SceneManager.LoadScene("LevelSelect");
        }
    }
}