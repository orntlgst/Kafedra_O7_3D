using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orient;

    float rotateX;
    float rotateY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float cursorY = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensY;
        float cursorX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

        rotateX += cursorX;
        rotateY += cursorY;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);
        transform.rotation = Quaternion.Euler(-rotateX, rotateY, 0);
        orient.rotation = Quaternion.Euler(0, rotateY, 0);
    }
}
