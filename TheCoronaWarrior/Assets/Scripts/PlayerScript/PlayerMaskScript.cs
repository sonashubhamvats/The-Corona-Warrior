using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerMaskScript : MonoBehaviour
{
    public GameObject mask,maskImage,timer;

    public Image maskTimerFill;
    public bool maskOn,inUse;

    public float currentTime;
    public TextMeshProUGUI maskCount,timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(maskImage.activeInHierarchy)
            {
                if((int)double.Parse(maskCount.text)>0)
                {
                    if(!inUse)
                    {
                        maskOn=true;
                        GetComponent<PlayerHealthScript>().MaskOn=true;
                        mask.SetActive(true);
                        timer.SetActive(true);
                        inUse=true;
                        InvokeRepeating("DecrementTimer",1f,1f);

                    }
                    
                }
            }
        }
    }
    void DecrementTimer()
    {
        timerText.text=((int)double.Parse(timerText.text)-1).ToString();
        maskTimerFill.fillAmount=(float)((float)double.Parse(timerText.text)/10f);
        if((int)double.Parse(timerText.text)==0)
        {
            inUse=false;
            maskOn=false;
            GetComponent<PlayerHealthScript>().MaskOn=false;
            mask.SetActive(false);
            timer.SetActive(false);
            timerText.text="10";
            maskCount.text=((int)double.Parse(maskCount.text)-1).ToString();
            maskTimerFill.fillAmount=1f;
            CancelInvoke();
        }
    }
    public void TakeMask()
    {
        maskImage.SetActive(true);
        maskCount.text=((int)double.Parse(maskCount.text)+1).ToString();
    }

}
