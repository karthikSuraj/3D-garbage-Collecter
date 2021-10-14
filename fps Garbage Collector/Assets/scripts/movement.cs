using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float Xrot = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
       
        Xrot -= mouseY;
        Xrot = Mathf.Clamp(Xrot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Xrot, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}