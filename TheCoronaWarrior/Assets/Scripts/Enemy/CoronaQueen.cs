using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaQueen : MonoBehaviour
{
    public GameObject spawnPoint,coronaBulletPrefab;

    private Transform[] spawnPoints=new Transform[13];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<spawnPoint.transform.childCount;i++)
        {
            spawnPoints[i]=spawnPoint.transform.GetChild(i);
        
        }
        InvokeRepeating("SpawnSol",0f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnSol()
    {
        for(int i=0;i<spawnPoint.transform.childCount;i++)
        {
            var temp=Instantiate(coronaBulletPrefab,transform.position,Quaternion.identity);
            temp.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity=(spawnPoints[i].position-transform.position).normalized*5f;
            ParticleManager.instance.ParticleEfectCoronaDead(transform.position);

        }
    }
}
