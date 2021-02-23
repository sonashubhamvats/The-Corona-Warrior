using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoronaQueenTrigger : MonoBehaviour
{
    public Image coronaHealthBar;

    public TextMeshProUGUI coronaQueenName;
    public GameObject queen_prefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(!queen_prefab.activeInHierarchy)
            {
                queen_prefab.SetActive(true);
            }
            coronaHealthBar.gameObject.SetActive(true);
            coronaQueenName.gameObject.SetActive(true);
        }
    }
}
