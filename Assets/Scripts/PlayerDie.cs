using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private Animator anim;
    private bool isDead = false;
    private PlayerMovement movement;
    private LoseUI loseUI;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        loseUI = FindFirstObjectByType<LoseUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("Retry"))
        {
            isDead = true;

            anim.SetTrigger("Die");
            movement.enabled = false;

            Invoke(nameof(ShowLose), 1.5f);
        }
    }

    void ShowLose()
    {
        loseUI.Show();
    }
}