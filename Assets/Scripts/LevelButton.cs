using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    [System.Serializable]
    public class LevelUI
    {
        public GameObject lockButton;
        public GameObject unlockButton;
        public int sceneIndex;
    }

    public LevelUI[] levels;

    void Start()
    {

        //PlayerPrefs.DeleteAll(); // reset toàn bộ

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 2);

        for (int i = 0; i < levels.Length; i++)
        {
            LevelUI level = levels[i];

            if (level.sceneIndex <= unlockedLevel)
            {
                // mở
                level.lockButton.SetActive(false);
                level.unlockButton.SetActive(true);

                Button btn = level.unlockButton.GetComponent<Button>();

                int index = level.sceneIndex;
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(index);
                });
            }
            else
            {
                // khóa
                level.lockButton.SetActive(true);
                level.unlockButton.SetActive(false);
            }
        }
    }
}