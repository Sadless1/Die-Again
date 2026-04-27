using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public PlayerMovement player;

    public void OnJumpPressed()
    {
        player.MobileJump();
    }
}