using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController playerController;
    public float speed;
    Vector3 currentVelo;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDist = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jump;

   public Transform playerTransform;
   public Transform teleportToNewZone;
   public Transform teleportToOldZone;

    private void Start()
    {
       // playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if(isGrounded && currentVelo.y < 0)
        {
            currentVelo.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
  
        playerController.Move(moveDirection * speed * Time.deltaTime);
        

        if(Input.GetButtonDown("Jump") && isGrounded )
        {
            currentVelo.y = Mathf.Sqrt(jump * -2f * gravity);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TeleportToNewZone();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            TeleportToOldZone();
        }

        currentVelo.y += gravity * Time.deltaTime;
        playerController.Move(currentVelo * Time.deltaTime);
    }



    public void TeleportToNewZone()
    {
        Vector3 moveDir = new Vector3(-500, 0.5f, 6);
        playerController.Move(moveDir);

    }

    public void TeleportToOldZone()
    {
        Vector3 moveDir = new Vector3(500, 0.5f, 6);
        playerController.Move(moveDir);
    }
}
