using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Update()
    {       
        bool goingLeft = Input.GetAxis("Horizontal") < 0;
        bool goingRight = Input.GetAxis("Horizontal") > 0;
        bool isWalkingForward = Input.GetAxis("Vertical") > 0;
        //Future work
        bool isWalkingBack = Input.GetAxis("Vertical") < 0;

        //For Debugs        
        //Debug.Log("Horizontal L " + goingLeft);
        //Debug.Log("Horizontal R " + goingRight);
        //Debug.Log("Horizontal VU" + isWalkingForward);
        //Debug.Log("Horizontal VD" + isWalkingBack);
        

        if (isWalkingForward)
        {
            animator.SetBool("walkAnim", isWalkingForward);
            animator.SetBool("rightAnim", false);
            animator.SetBool("leftAnim", false);
        }
        else
            animator.SetBool("walkAnim", false);             

        if (goingLeft) 
        {
            animator.SetBool("leftAnim", goingLeft);
            animator.SetBool("idleLeft", false);
            animator.SetBool("rightAnim", false);
            animator.SetBool("walkAnim", false);
        }
        else
        {
            animator.SetBool("idleLeft", true);
            animator.SetBool("leftAnim", false);
        }

        if (goingRight)
        {
            animator.SetBool("rightAnim", goingRight);
            animator.SetBool("idleRight", false);
            animator.SetBool("leftAnim", false);
        }
        else
        {
            animator.SetBool("idleRight", true);            
        }
    }
}
