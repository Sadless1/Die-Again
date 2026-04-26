using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSelectLevel : MonoBehaviour
{
    public void GoSelectLevel()
    {
        SceneManager.LoadScene(1);
    }
}
