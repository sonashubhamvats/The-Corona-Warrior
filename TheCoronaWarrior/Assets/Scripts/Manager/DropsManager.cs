using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropsManager : MonoBehaviour
{
    public Image bulletImage;

    public TextMeshProUGUI bulletCountText; 
    // Start is called before the first frame update
    public static DropsManager instance;
    public float medHealthGain;
    public PlayerHealthScript playerHealthScript;
    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        
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
    public void TakeInHealth()
    {
        playerHealthScript.health+=medHealthGain;
        if(playerHealthScript.health>100f)
        {
            playerHealthScript.health=100f;
        }
        playerHealthScript.healthBar.fillAmount=(float)((float)playerHealthScript.health/100f);
    }
    public void GunTakeIn()
    {
        bulletImage.gameObject.SetActive(true);
        FindObjectOfType<PlayerWeaponManager>().gotWeapon=true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
