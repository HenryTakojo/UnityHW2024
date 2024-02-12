using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodViewMouseCtrl : MonoBehaviour
{
    public CharacterController cc;
    public float moveSpeed = 1.0f;
    public TPSTarget lookTarget;
    public float followDistance;
    public Transform camTransform;
    private Vector3 horizontalDirection;
    private float verticalDegree = 0.0f;
    public float camCtrlSensitive = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalDirection = transform.forward;
    }

    

    // Update is called once per frame
    void Update()
    {
        float fMoveV = Input.GetAxis("Vertical");
        float fMoveH = Input.GetAxis("Horizontal");
        if(fMoveV != 0 ||  fMoveH != 0)
        {
            Vector3 vCamF = camTransform.forward;
            vCamF.y = 0;
            vCamF.Normalize();

            Vector3 vCamR = camTransform.right;
            Vector3 VecF = fMoveV * vCamF;
            Vector3 VecR = fMoveH * vCamR;
            VecF = VecF + VecR;
            //float inputSpeed = VecF.magnitude;
            //if(inputSpeed > 1.0)
            //{
                //inputSpeed = 1.0f;
            //}
            transform.forward = Vector3.Lerp(transform.forward, vCamF, 0.1f);
            cc.SimpleMove( VecF *  moveSpeed);
        }
        //transform.Rotate(0, fMoveH, 0);


        lookTarget.UpdateTarget();
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        verticalDegree = verticalDegree + mouseY * camCtrlSensitive;
        if (verticalDegree > 60.0f) {
            verticalDegree = 60.0f;
        }
        else if (verticalDegree < -30.0f)
        {
            verticalDegree = -30.0f;
        }

        RaycastHit rh;
        

        horizontalDirection = Quaternion.Euler(0, mouseX * camCtrlSensitive, 0) * horizontalDirection;
        Vector3 vAxis = Vector3.Cross(Vector3.up, horizontalDirection);
        Vector3 finalVector = Quaternion.AngleAxis(verticalDegree, vAxis) * horizontalDirection;
        Vector3 camPos = lookTarget.transform.position - finalVector * followDistance;
        camTransform.position = camPos;
        camTransform.LookAt(lookTarget.transform.position);

    }
}
