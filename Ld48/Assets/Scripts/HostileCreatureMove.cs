using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HostileCreatureMove : MonoBehaviour
{
    public Transform goal;
    public float health;
    // Start is called before the first frame update
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            health -= 100;
        }
        if (other.CompareTag("Bullet"))
        {
            health -= 1;
        }
        if (health <= 0)
        {
            //graphics
            Destroy(gameObject);
        }
    }
}
