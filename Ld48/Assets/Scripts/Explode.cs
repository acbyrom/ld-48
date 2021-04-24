using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void StartTimer(float boomTimer)
    {
        StartCoroutine(Explosion(boomTimer));
        //update graphics
    }

    private IEnumerator Explosion(float boomTimer)
    {
        yield return new WaitForSeconds(boomTimer);
        gameObject.GetComponent<SphereCollider>().enabled = true;
        //particle effects
        //deparent and destroy ^
        Destroy(gameObject);
    }
}
