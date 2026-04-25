using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;

            // Lưu tiến trình
            PlayerPrefs.SetInt("Level", nextScene);

            // Load level tiếp
            SceneManager.LoadScene(nextScene);
        }
    }
}