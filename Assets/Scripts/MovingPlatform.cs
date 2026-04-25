using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    public Vector3 moveDirection = Vector3.right;

    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (movingForward)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);

            if (Vector3.Distance(startPos, transform.position) >= distance)
                movingForward = false;
        }
        else
        {
            transform.Translate(-moveDirection * speed * Time.deltaTime);

            if (Vector3.Distance(startPos, transform.position) <= 0.1f)
                movingForward = true;
        }
    }

    // 👇 Fix player bị trượt
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}