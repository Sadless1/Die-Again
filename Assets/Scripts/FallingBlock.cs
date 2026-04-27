using System.Collections;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Rigidbody[] blocks;
    public float delay = 0.5f;

    private bool isTriggered = false;

    private void Start()
    {
        foreach (Rigidbody rb in blocks)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);

        foreach (Rigidbody rb in blocks)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}