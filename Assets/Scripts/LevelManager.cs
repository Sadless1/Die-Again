using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int unlockedLevel;

    void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // FIX CỨNG
        if (unlockedLevel < 1)
        {
            unlockedLevel = 1;
            PlayerPrefs.SetInt("UnlockedLevel", 1);
            PlayerPrefs.Save();
        }
    }

    public static void UnlockNextLevel(int currentLevel)
    {
        if (currentLevel >= unlockedLevel)
        {
            unlockedLevel = currentLevel + 1;
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
            PlayerPrefs.Save();
        }
    }
}