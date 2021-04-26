using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HostileCreatureMove : MonoBehaviour
{
    public Transform goal;
    public float health;
    public GameObject particles;
    NavMeshAgent agent = GetComponent<NavMeshAgent>();
    // Start is called before the first frame update
    void Update()
    {
        agent.destination = goal.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            health -= 100;
        }
        if (other.transform.CompareTag("Bullet"))
        {
            health -= 1;
        }
        if (health <= 0)
        {
            //graphics
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            var ptcs = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(ptcs, 6f);
            Destroy(gameObject);
        }
    }
}
