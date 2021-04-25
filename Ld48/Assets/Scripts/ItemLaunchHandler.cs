using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLaunchHandler : MonoBehaviour
{
    public bool recentlyLaunchedItem = false;
    public bool recentlyShot = false;

    public float itemLaunchCooldown;
    public float itemLaunchVelocity;

    public float grenadeCooldown;
    public float gunCooldown;

    public GameObject Grenade;
    public GameObject Bullet;
    public Transform hand;
    public KeyCode shoot;
    public KeyCode drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!recentlyLaunchedItem)
        {
            if (Input.GetKeyDown(drop))
            {
                LaunchGrenade();
                recentlyLaunchedItem = true;
                StartCoroutine(ItemLaunchCountdown());
            }
        if (!recentlyShot)
            {
                if (Input.GetKeyDown(shoot))
                {
                    ShootBullet();
                    recentlyShot = true;
                    StartCoroutine(GunCountdown());
                }
            }
        }
    }
    void ShootBullet()
    {
        var shotBullet = Instantiate(Bullet, hand.position, Quaternion.identity);
        shotBullet.GetComponent<Rigidbody>().AddForce(hand.forward * itemLaunchVelocity);
        Destroy(shotBullet, 5f);
    }
    IEnumerator GunCountdown()
    {
        yield return new WaitForSeconds(gunCooldown);
        recentlyShot = false;
    }
    void LaunchGrenade()
    {
        var launchedGrenade = Instantiate(Grenade, hand.position, Quaternion.identity);
        launchedGrenade.GetComponent<Rigidbody>().AddForce(hand.forward * itemLaunchVelocity) ;
        launchedGrenade.GetComponent<Explode>().StartTimer(grenadeCooldown);

    }
    IEnumerator ItemLaunchCountdown()
    {
        yield return new WaitForSeconds(itemLaunchCooldown);
        recentlyLaunchedItem = false;
    }
}
