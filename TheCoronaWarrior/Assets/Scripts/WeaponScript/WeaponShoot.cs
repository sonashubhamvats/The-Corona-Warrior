using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WeaponShoot : MonoBehaviour
{
    public GameObject bulletPrefab,Crosshair;
    public Camera main_camera;
    public Animator this_anim;

    public int bulletCount;

    public TextMeshProUGUI bulletCountText;
    
    public Transform invert_tranform,spawnPoint;

    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this_anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Aim();   
        CheckForShoot();
    }
    void CheckForShoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int ammoCount=(int)double.Parse(bulletCountText.text);
            if(ammoCount>0)
            {
                ammoCount--;
                bulletCountText.text=ammoCount.ToString();
                this_anim.SetTrigger("shoot");
                var temp=Instantiate(bulletPrefab,spawnPoint.position,Quaternion.identity);
                var velo=(Crosshair.transform.position-spawnPoint.position).normalized*bulletSpeed;
                temp.GetComponent<Rigidbody2D>().velocity=velo;
            }
        }
    }
    void Aim()
    {
        Vector3 mousePosition=main_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection=(mousePosition-transform.position).normalized;

        Crosshair.transform.position=new Vector3(mousePosition.x,mousePosition.y,0f);

        float angle=Mathf.Atan2(aimDirection.y,aimDirection.x)*Mathf.Rad2Deg;
        if(angle>=90||angle<=-90f)
        {
           
            var pos=transform.localPosition;
            if(pos.x>0f)
            {
                pos.x*=-1f;

            }
            transform.localPosition=pos;

            var scale=transform.localScale;
            if(scale.y>0f)
            {
                scale.y*=-1f;

            }
            transform.localScale=scale;
           


            var invert=invert_tranform.localScale;
            if(invert.x>0f)
            {
                invert.x*=-1f;
            }
            invert_tranform.localScale=invert;
        }
        else
        {
            var pos=transform.localPosition;
            if(pos.x<0f)
            {
                pos.x*=-1f;

            }
            transform.localPosition=pos;

            var scale=transform.localScale;
            if(scale.y<0f)
            {
                scale.y*=-1f;

            }
            transform.localScale=scale;

            var invert=invert_tranform.localScale;
            if(invert.x<0f)
            {
                invert.x*=-1f;
            }
            invert_tranform.localScale=invert;

        }
        transform.eulerAngles=new Vector3(0f,0f,angle);
        
    }
}
