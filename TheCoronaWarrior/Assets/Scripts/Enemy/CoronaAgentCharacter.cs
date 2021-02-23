using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum type
{
    vert,hor
}
public class CoronaAgentCharacter : MonoBehaviour
{
    public Image CoronahealthBar;
    public type typeOfAgent;
    public float speed;

    public int healthNo;
    public bool either;
    public Transform oneEx,otherEx;

    public Transform player;

    private Animator this_anim;
    // Start is called before the first frame update
    void Start()
    {
        
        this_anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(typeOfAgent==type.hor)
        {
            if(oneEx.position.x>transform.position.x)
            {
                var scale=transform.localScale;
                scale.x*=-1f;
                transform.localScale=scale;
                either=true;
            }
            else if(otherEx.position.x<transform.position.x)
            {
                var scale=transform.localScale;
                scale.x*=-1f;
                transform.localScale=scale;

                either=false;
            }
            if(!either)
            {
                transform.Translate(Vector2.left*Time.deltaTime*speed);

            }
            else
            {
                transform.Translate(Vector2.right*Time.deltaTime*speed);
                
            }

        }
        else
        {
            if(oneEx.position.y<transform.position.y)
            {
                either=true;
            }
            else if(otherEx.position.y>transform.position.y)
            {
                either=false;
            }
            if(!either)
            {
                transform.Translate(Vector2.up*Time.deltaTime*speed);

            }
            else
            {
                transform.Translate(Vector2.down*Time.deltaTime*speed);
                
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bullet")
        {
 

            this_anim.SetTrigger("hurt");
            healthNo--;
            if(gameObject.transform.parent.gameObject.name=="CoronaQueen")
            {
                Debug.Log("Yo");
                CoronahealthBar.fillAmount=(float)((float)healthNo/40f);
            }
            ParticleManager.instance.ParticleEffectBulletDestroy(other.transform.position);
            other.GetComponent<BoxCollider2D>().enabled=false;
            
            if(healthNo==0)
            {
                Destroy(gameObject);
                ParticleManager.instance.ParticleEfectCoronaDead(transform.position);
                if(gameObject.transform.parent.gameObject.name=="CoronaQueen")
                {
                    Debug.Log("Win");
                    Time.timeScale=0f;
                    ButtonManager.instance.congrats_panel.SetActive(true);
                }
            }
            Debug.Log("Hell");
        }
    }

}
