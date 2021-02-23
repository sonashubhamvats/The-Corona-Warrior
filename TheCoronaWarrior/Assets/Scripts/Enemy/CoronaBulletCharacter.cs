using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaBulletCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyy()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destroyy()
    {
        yield return new WaitForSeconds(3f);
        ParticleManager.instance.ParticleEfectCoronaDead(transform.GetChild(0).position);
        Destroy(gameObject);
    }
}
