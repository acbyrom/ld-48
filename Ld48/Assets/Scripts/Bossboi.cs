using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossboi : MonoBehaviour
{
    public float health;
    public GameObject[] minions;
    public Transform player;
    float maxHealth;
    private void Start()
    {
        maxHealth = health;
        StartCoroutine("Summon");
    }
    IEnumerator Summon()
    {
        yield return new WaitForSeconds(Random.value * 10);
        var enem = Instantiate(minions[Random.Range(0, minions.Length - 1)],transform.position,transform.rotation);
        enem.GetComponent<HostileCreatureMove>().goal = player;
        StartCoroutine("Summon");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            health -= 100;
        }
        else if (other.transform.CompareTag("Bullet"))
        {
            health -= 10;
        }
        if (health <= 0)
        {
            Destroy(transform.parent.parent.parent.parent.gameObject);
        } else
        {
            RenderSettings.ambientIntensity = (health / maxHealth);
        }

    }
}
