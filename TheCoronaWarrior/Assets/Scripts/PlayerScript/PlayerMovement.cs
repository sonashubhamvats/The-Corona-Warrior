using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform this_transform;
    public Animator this_anim;

    private bool onground;
    public float speed;

    public LayerMask tileLayer;

    public Transform checkGround;
    public float force;

    private float jump_count;

    private Rigidbody2D this_rigidBody;
    // Start is called before the first frame update
    private void Awake()
    {
        this_transform=GetComponent<Transform>();
        this_rigidBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMovement();
        CheckGround();
        CheckForJump();
 
    }
    private void CheckForMovement()
    {
        var pos=this_transform.position;
        float x=Input.GetAxis("Horizontal");
        if(x>0f)
        {
            if(onground)
            {
                var scale=transform.localScale;
                if(scale.x<0f)
                {
                    scale.x*=-1f;
                }
                transform.localScale=scale;

                this_anim.SetBool("walk",true);
 

            }
            else
            {
                this_anim.SetBool("walk",false);


            }

        }
        else if(x<0f)
        {
            if(!PlayerWeaponManager.instance.withWeapon)
            {
                var scale=transform.localScale;
                if(scale.x>0f)
                {
                    scale.x*=-1f;
                }
                transform.localScale=scale;
            }
            if(onground)
            {
                this_anim.SetBool("walk",true);
 

            }
            else
            {
                this_anim.SetBool("walk",false);

            }

  
        }
        else
        {
            this_anim.SetBool("walk",false);
        }
        pos.x+=x*speed;
        this_transform.position=pos;
        if(x==0f)
        {
            var velo=this_rigidBody.velocity;
            velo.x=0f;
            this_rigidBody.velocity=velo;
        }
    }
    private void CheckForJump()
    {
        if(onground)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jump_count++;
                onground=false;
                this_anim.SetTrigger("jump");
                this_rigidBody.AddForce(new Vector3(0f,1f,0f)*force);
            }
        }
        else
        {
            if(jump_count==1)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    this_rigidBody.AddForce(new Vector3(0f,1f,0f)*force);
                    jump_count++;

                }
            }
        }
    }
    private void CheckGround()
    {
        if(Physics2D.OverlapCircle(checkGround.position,0.02f,tileLayer))
        {
            onground=true;
            jump_count=0;
            
            if(this_anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerJump"))
            {
                this_anim.SetBool("jumpEnd",true);
            }
        }
        else
        {
            onground=false;
            this_anim.SetBool("jumpEnd",false);
        }
        
    }
}
