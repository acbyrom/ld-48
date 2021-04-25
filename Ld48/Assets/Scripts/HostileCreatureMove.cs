using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HostileCreatureMove : MonoBehaviour
{
    public bool isMobile = true;
    public Transform goal;
    public float health;
    public GameObject particles;

    public float staticRange = 3f;
    public GameObject staticAttackSphere;

    void Update()
    {
        if (isMobile)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
        }
        else
        {
            float distance = Vector3.Distance(goal.transform.position, this.transform.position);
            if (distance <= staticRange)
            {
                staticAttackSphere.SetActive(true);
            } else
            {
                staticAttackSphere.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            health -= 100;
        }
        else if (other.transform.CompareTag("Bullet"))
        {
            health -= 1;
        }
        if (health <= 0)
        {
            var ptcs = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(ptcs, 6f);
            Destroy(gameObject);
        }
    }
}
