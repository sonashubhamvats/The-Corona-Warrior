using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum itemType
{
    med,ammo,gun,mask
}
public class ItemScript : MonoBehaviour
{
    public itemType type;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,speed*Time.deltaTime,0f));
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            if(type==itemType.med)
            {
                DropsManager.instance.TakeInHealth();

            }
            else if(type==itemType.gun)
            {
                DropsManager.instance.GunTakeIn();
            }
            else if(type==itemType.ammo)
            {
                int ammoCount=(int)double.Parse(FindObjectOfType<DropsManager>().bulletCountText.text);
                ammoCount+=10;
                if(ammoCount>20)
                {
                    ammoCount=20;
                }
                FindObjectOfType<DropsManager>().bulletCountText.text=ammoCount.ToString();
            }
            else if(type==itemType.mask)
            {
                FindObjectOfType<PlayerMaskScript>().TakeMask();
            }
            gameObject.SetActive(false);
        }
    }
}
