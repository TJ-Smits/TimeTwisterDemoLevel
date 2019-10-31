using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float lookSensitivity = 2.0f;

    private new Camera camera;

    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float horizontalMouseInput = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float VerticalMouseInput = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

        xRotation -= VerticalMouseInput;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * horizontalMouseInput);
    }
}
