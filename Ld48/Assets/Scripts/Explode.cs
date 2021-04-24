using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject particleObject;

    public void StartTimer(float boomTimer)
    {
        StartCoroutine(Explosion(boomTimer));
        //update graphics
    }

    private IEnumerator Explosion(float boomTimer)
    {
        yield return new WaitForSeconds(boomTimer);
        gameObject.tag = "Explosion";
        gameObject.GetComponent<SphereCollider>().enabled = true;
        var particles = Instantiate(particleObject, transform.position, Quaternion.identity);
        Destroy(particles, 10);
        Destroy(gameObject,0.1f);
    }
}
