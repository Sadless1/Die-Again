using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int levelIndex; // set trong Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.UnlockNextLevel(levelIndex);

            SceneManager.LoadScene("LevelSelect");
        }
    }
}