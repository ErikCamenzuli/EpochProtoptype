using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float mouseSens = 100f;
    public Transform player;
    private float xRotate = 0f;

    // Update is called once per frame
    void Update()
    {
        float mouseInX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseInY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotate -= mouseInY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        player.Rotate(Vector3.up * mouseInX);

    }
}
