using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private float _direction;
    private bool _jumping;

    private Vector3 moveDirection = Vector3.zero;
    private bool canMoveVertical;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (canMoveVertical)
        {
            ComputeVelocityVertical();
        }
        else
            ComputeVelocity();

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Update()
    {
        GetInputs();
    }
    private void ComputeVelocity()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;

            if (_jumping)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
    }
    private void ComputeVelocityVertical()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (_jumping)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
    }

    public void SetVerticalMove()
    {
        canMoveVertical = true;
    }

    public void ResetSpeed(Vector3 position)
    {
        characterController.enabled = false;
        transform.position = position;
        characterController.enabled = true;
    }

    private void GetInputs()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        _jumping = Input.GetButton("Jump");
    }
}
