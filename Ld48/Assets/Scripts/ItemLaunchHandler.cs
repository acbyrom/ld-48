using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLaunchHandler : MonoBehaviour
{
    public bool recentlyLaunchedItem = false;
    public float itemLaunchCooldown;
    public float itemLaunchVelocity;
    public float grenadeCooldown;
    public GameObject Grenade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!recentlyLaunchedItem)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                LaunchGrenade();
                recentlyLaunchedItem = true;
                StartCoroutine(ItemLaunchCountdown());
            }
        }
    }
    void LaunchGrenade()
    {
        var launchedGrenade = Instantiate(Grenade, transform.position, Quaternion.identity);
        launchedGrenade.GetComponent<Rigidbody>().AddForce(transform.forward*itemLaunchVelocity) ;
        launchedGrenade.GetComponent<Explode>().StartTimer(grenadeCooldown);

    }
    IEnumerator ItemLaunchCountdown()
    {
        yield return new WaitForSeconds(itemLaunchCooldown);
        recentlyLaunchedItem = false;
    }
}
