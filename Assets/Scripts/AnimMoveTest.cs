using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMoveTest : MonoBehaviour
{
    private bool bNextAttack = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("StandA_idleA"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // anim.SetBool("boolAttack", true);
                anim.SetTrigger("triggerAttack");
            }

        }
        else
        {
            if (bNextAttack)
            {
                Debug.Log(bNextAttack + ":" + Time.realtimeSinceStartup);
                // left mouse btn down
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetInteger("AttackIndex", 1);
                }
            }
        }
    }

    void WalkEvent(float f)
    {
        Debug.Log("WalkEvent " + f);
    }

    void Attack1_Start()
    {
        Debug.Log("Attack1_Start");
        bNextAttack = true;
    }

    void Attack1_End()
    {
        bNextAttack = false;
    }
}
