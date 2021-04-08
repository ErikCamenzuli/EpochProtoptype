using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController playerController;
    public float speed;
    Vector3 velocity;
    public float gravity;
    public float velocityDrop;
    public Transform groundCheck;
    private float distanceToGround = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, distanceToGround, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = velocityDrop;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        playerController.Move(moveDirection * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * velocityDrop * gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);


    }
}
