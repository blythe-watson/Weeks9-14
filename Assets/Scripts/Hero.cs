using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //when talking about the sprite renderer and animation attached to the component that this script is on, these are the terms we'll use to address them
    SpriteRenderer sr;
    Animator animator;
    public float speed = 6;
    public bool canRun = true;

    // Start is called before the first frame update
    void Start()
    {
        //script, please be aware that there is a sprite rendere and an animator on the component you're on, and that's what these terms refer to
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //direction is a built in function for WASD, arrow keys, and joysticks that returns 1, -1, or 0 meaning right, left, or static.
        float direction = Input.GetAxisRaw("Horizontal");

        //is direction < 0.1 true or false? if true then flipX equals true and flips.
        //sr.flipX = direction < 0;

        //if direction is greater than 0.1, don't flip X, since the sprite faces right by default
        if(direction > 0.1)
        {
            sr.flipX = false;
        }
        //if direction is less than -0.1, meaning left, flip X in the sprite renderer
        if(direction < -0.1)
        {
            sr.flipX = true;
        }

        //we attached an animator component to the hero which has a float parameter named movement.
        //some transitions using movement rely on whether it is 0 or greater than 0.1.
        //get the absolute (non-negative) value of direction, which will return as either 0 or 1, meaning static or moving
        animator.SetFloat("movement", Mathf.Abs(direction));

        //for the attack animation, we have a trigger
        //when you click, activate the trigger and disable your ability to run
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        //if you can run, transform your speed by direction (which can be 0) times your speed times delta time
        if (canRun)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

    }

    //when you finish attacking, reenable running
    //in the animation window (different from the Animator), we placed an animation event on the last frame of the attack animation
    //that event calls this public void
    public void AttackHasFinished()
    {
        Debug.Log("Attack animation is finished, boss!");
        canRun = true;
    }
}
