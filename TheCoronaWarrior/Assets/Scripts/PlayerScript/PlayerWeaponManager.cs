using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public GameObject player_gun,crossHair,player_body,hand;

    public static PlayerWeaponManager instance;

    public bool withWeapon,gotWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();

        withWeapon=false;
    }
    void MakeInstance()
    {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!withWeapon)
            {
                var scale=transform.localScale;
                if(scale.x<0f)
                {
                    scale.x*=-1f;
                }
                transform.localScale=scale;

                GiveWeapon();

            }
            else
            {
                var invert=player_body.transform.localScale;
                if(invert.x<0f)
                {
                    invert.x*=-1f;
                }
                player_body.transform.localScale=invert;

                TakeOutWeapon();
            }
        }        
    }
    public void GiveWeapon()
    {
        if(gotWeapon)
        {
            player_gun.gameObject.SetActive(true);
            crossHair.gameObject.SetActive(true);
            hand.SetActive(false);
            withWeapon=true;

        }
    }
    public void TakeOutWeapon()
    {
        player_gun.gameObject.SetActive(false);
        crossHair.gameObject.SetActive(false);
        hand.SetActive(true);
        withWeapon=false;

    }
}
