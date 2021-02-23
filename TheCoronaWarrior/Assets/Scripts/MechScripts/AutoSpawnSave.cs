using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoSpawnSave : MonoBehaviour
{
    public Image timer,coronaHealthBar;
    public TextMeshProUGUI coronaName,ammo,mask_count,timerCount;
    private List<GameObject> items=new List<GameObject>();

    public GameObject itemParent;
    public Transform sp1,sp2,sp3;

    public int ammoCount;

    public int maskCount;
    public static AutoSpawnSave instance;
    public Transform current_spawn_point;


    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        ammoCount=10;
        maskCount=0;
        for(int i=0;i<itemParent.transform.childCount;i++)
        {
            items.Add(itemParent.transform.GetChild(i).gameObject);
        }
        current_spawn_point=sp1;
        MakeInstance();
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
    public void Spawn()
    {
        player.transform.position=current_spawn_point.position;
        for(int i=0;i<items.Count;i++)
        {
            items[i].SetActive(true);
        }
        if((int)(double.Parse(ammo.text))<10f)
        {
            ammoCount=10;
            ammo.text=ammoCount+"";

        }
        coronaHealthBar.gameObject.SetActive(false);
        coronaName.gameObject.SetActive(false);
        maskCount=0;
        mask_count.text=maskCount+"";
        timerCount.text="10";
        player.GetComponent<PlayerHealthScript>().health=100f;
        player.GetComponent<PlayerHealthScript>().healthBar.fillAmount=1f;
        timer.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }
    public void ChangeToSp2()
    {
        current_spawn_point=sp2;
    }
    public void ChangeToSp3()
    {
        current_spawn_point=sp3;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
