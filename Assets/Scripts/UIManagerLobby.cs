using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerLobby : MonoBehaviour
{
    public void BackToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
