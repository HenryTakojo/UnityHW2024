using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody rb;
    public Transform camTrans;
    public float moveSpeed;
    public float jumpSpeed;
    private bool bJump = false;
    private float fMoveV = 0.0f;
    private float fMoveH = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bJump = true;
        }
        fMoveV = Input.GetAxis("Vertical");
        fMoveH = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        Vector3 moveVel = Vector3.zero;
        Vector3 mDir = Vector3.zero;
        Vector3 oldVel = rb.velocity;
        if (fMoveV != 0 || fMoveH != 0)
        {

            if (fMoveV != 0)
            {
                // moveVel += transform.forward * 2.0f* fMoveV;
                mDir = camTrans.forward * fMoveV;
                mDir.y = 0;
            }

            if (fMoveH != 0)
            {
                Vector3 tempDir = camTrans.right * fMoveH;
                tempDir.y = 0.0f;
                mDir += tempDir;
            }
            //mDir.Normalize(); // unity do normalize in forward setting
            transform.forward = mDir;
            moveVel = transform.forward * moveSpeed;

        }


        moveVel.y = oldVel.y;
        rb.velocity = moveVel;

        if (bJump)
        {

            rb.velocity = Vector3.up*jumpSpeed;
            bJump = false;
        }

        
    }
}
