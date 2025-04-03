using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickWalkHero : MonoBehaviour
{
    //when talking about the sprite renderer and animation attached to the component that this script is on, these are the terms we'll use to address them
    SpriteRenderer sr;
    Animator animator;
    AudioSource audio;
    CinemachineImpulseSource impulseSource;
    public float speed = 6;
    public bool canRun = true;


    //make an array for the footstep sounds
    public AudioClip[] footsteps;
    public AudioClip step1;


    public Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        //script, please be aware that there is a sprite renderer and an animator on the component you're on, and that's what these terms refer to
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction is a built in function for WASD, arrow keys, and joysticks that returns 1, -1, or 0 meaning right, left, or static.
        float direction = Input.GetAxisRaw("Horizontal");

        //is direction < 0.1 true or false? if true then flipX equals true and flips.
        //sr.flipX = direction < 0;

        //if direction is greater than 0.1, don't flip X, since the sprite faces right by default
        if (direction > 0.1)
        {
            sr.flipX = false;
        }
        //if direction is less than -0.1, meaning left, flip X in the sprite renderer
        if (direction < -0.1)
        {
            sr.flipX = true;
        }


        //we attached an animator component to the hero which has a float parameter named movement.
        //some transitions using movement rely on whether it is 0 or greater than 0.1.
        //get the absolute (non-negative) value of direction, which will return as either 0 or 1, meaning static or moving
        animator.SetFloat("movement", Mathf.Abs(direction));

        //if you can run, transform your speed by direction (which can be 0) times your speed times delta time
        /*if (canRun)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }*/

        
        Vector2 path = mousePos - transform.position;

        if (Input.GetMouseButtonDown(0) && canRun == true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            //transform.position
        }

        //for the attack animation, we have a trigger
        //when you click, activate the trigger and disable your ability to run
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hiyah!");
            animator.SetTrigger("attack");
            canRun = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("leap!");
            animator.SetTrigger("jump");
            //transform.position += transform.up;
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

    public void Steppy()
    {
        Debug.Log("tippy tappy");
        //audio.PlayOneShot(step1);
        int randomNumber = Random.Range(0, footsteps.Length);
        audio.PlayOneShot(footsteps[randomNumber]);
        impulseSource.GenerateImpulse();
    }

}

