using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float speed = 5f;
    public float jumpForce = 7f;
    public float gravity = -15f;

    private Vector3 velocity;
    private bool jumpPressed;

    public JoystickController joystick;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // input
        float inputH = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float inputV = Input.GetAxis("Vertical") + joystick.Vertical;
        Vector3 inputDir = new Vector3(inputH, 0, inputV).normalized;

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            jumpPressed = true;
        }

        //  Gravity
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (jumpPressed)
            {
                velocity.y = jumpForce;

                // nếu chưa có animation thì comment dòng này
                if (animator != null)
                    animator.SetTrigger("Jump");

                jumpPressed = false;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Rotation & Movement
        if (inputDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

            Vector3 moveDir = targetRotation * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        // Gravity
        controller.Move(velocity * Time.deltaTime);

        // Animation
        if (animator != null)
        {
            animator.SetFloat("Speed", inputDir.magnitude);
        }
    }

    public void MobileJump()
    {
        if (controller.isGrounded)
        {
            jumpPressed = true;
        }
    }
}