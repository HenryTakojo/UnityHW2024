using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodViewCamCtrl : MonoBehaviour
{
    public Transform followTarget;
    public float followDistance;
    private Vector3 followDirection;
    // Start is called before the first frame update
    void Start()
    {
        followDirection = transform.position - followTarget.position;
        followDistance = followDirection.magnitude;
        followDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
