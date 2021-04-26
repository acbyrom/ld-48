using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossboi : MonoBehaviour
{
    public float health;
    public GameObject[] minions;
    public Transform player;
    public GameObject particles;
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
            health -= 10;
        }
        else if (other.transform.CompareTag("Bullet"))
        {
            health -= 10;
        }
        if (health <= 0)
        {
            var ptcs = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(ptcs, 6f);
            Destroy(transform.parent.parent.parent.parent.gameObject,2f);
            Time.timeScale = 0;
            player.GetComponent<PlayerMovement>().Win();
        } else
        {
            RenderSettings.ambientIntensity = (health / maxHealth);
        }

    }
}
