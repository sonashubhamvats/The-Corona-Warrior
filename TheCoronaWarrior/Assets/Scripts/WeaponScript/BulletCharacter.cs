using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCharacter : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(OnDestroyy());
    }
    IEnumerator OnDestroyy()
    {
        yield return new WaitForSeconds(3f);
        ParticleManager.instance.ParticleEffectBulletDestroy(transform.position);
        Destroy(gameObject);
    }
}
