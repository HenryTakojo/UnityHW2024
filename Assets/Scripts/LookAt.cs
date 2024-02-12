using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject cameraObj;
    public Transform target;
    

    void Start()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 vLook = transform.position - cameraObj.transform.position;
        vLook = vLook.normalized;
        float hmove = 10f;

        
        cameraObj.transform.position = transform.position + new Vector3(0, 0.6f, -2.5f);
        Debug.DrawLine(transform.position, target.position);
    }
}
