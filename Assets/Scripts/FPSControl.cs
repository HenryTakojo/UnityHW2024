using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour
{

    public Transform controlCamera;
    public Transform cameraControlPt;
    public float rotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = transform.position - controlCamera.position;

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }


    public void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        float rotateAmount = mouseX * rotateSpeed;

        controlCamera.Rotate(mouseY, 0, 0, Space.Self);
        controlCamera.Rotate(0, rotateAmount, 0, Space.World);

    }
}
