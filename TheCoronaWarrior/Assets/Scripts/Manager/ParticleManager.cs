using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem coronaDead,saniDestroy;
    public static ParticleManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
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
    public void ParticleEfectCoronaDead(Vector3 pos)
    {
        var par= Instantiate(coronaDead,pos,Quaternion.identity);
        StartCoroutine(destroyy(par));
    }
    public void ParticleEffectBulletDestroy(Vector3 pos)
    {
        var par=Instantiate(saniDestroy,pos,Quaternion.identity);
        StartCoroutine(destroyy(par));
    }
    IEnumerator destroyy(ParticleSystem part)
    {
        yield return new WaitForSeconds(3f);
        Destroy(part);
    }
}
