using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody camera;
    public float moveAmount;
    bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 vForward = transform.position - camera.transform.position;
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        { isJump = true; }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        if(isJump)
        {
            rb.AddForce(Vector3.up*5, ForceMode.Impulse);
            isJump = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
          rb.AddForce(Vector3.forward * moveAmount, ForceMode.Impulse);
        }
    }
}