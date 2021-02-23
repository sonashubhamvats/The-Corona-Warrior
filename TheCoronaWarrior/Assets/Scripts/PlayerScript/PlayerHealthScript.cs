using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthScript : MonoBehaviour
{
    public Image healthBar;

    public bool MaskOn;

    public float health;

    public float damageToItAgent,damageCoronaBullets,damageQueen;

    public Animator this_anim;

 
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag=="CoronaEffect")
        {
            if(!MaskOn)
            {
                if(!this_anim.GetNextAnimatorStateInfo(0).IsName("playerHurt"))
                {
                    this_anim.SetTrigger("hurt");

                }
                health-=damageToItAgent;
                healthBar.fillAmount=(float)((float)health/100f);
                if(health<=0f)
                {
                    Debug.Log("Dead");
                    gameObject.SetActive(false);
                    AutoSpawnSave.instance.Spawn();
                }

            }
        }  
        else if(other.gameObject.tag=="CoronaEffectOfQueen")
        {
            if(!MaskOn)
            {
                if(!this_anim.GetNextAnimatorStateInfo(0).IsName("playerHurt"))
                {
                    this_anim.SetTrigger("hurt");

                }
                health-=damageQueen;
                healthBar.fillAmount=(float)((float)health/100f);
                if(health<=0f)
                {
                    Debug.Log("Dead");
                    gameObject.SetActive(false);
                    AutoSpawnSave.instance.Spawn();
                    
                }

            }

        }
        else if(other.gameObject.tag=="CoronaSol")
        {
            if(!MaskOn)
            {
                if(!this_anim.GetNextAnimatorStateInfo(0).IsName("playerHurt"))
                {
                    this_anim.SetTrigger("hurt");

                }
                health-=damageCoronaBullets;
                healthBar.fillAmount=(float)((float)health/100f);
                if(health<=0f)
                {
                    Debug.Log("Dead");
                    gameObject.SetActive(false);
                    AutoSpawnSave.instance.Spawn();
                    
                }

            }

        }  
  
    }
}
