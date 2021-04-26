using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public AudioClip die;
    public AudioClip door;

    public float speed = 6f;
    public float gravity = -15f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject sceneTransition;
    Vector3 velocity;
    bool isGrounded;
    new AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HurtsPlayer"))
        {
            audio.clip = die;
            audio.Play();
            PersistentData.totalDeaths += 1;
            sceneTransition.GetComponent<SceneTransition>().Die();
        }
        else if (other.CompareTag("Explosion"))
        {
            audio.clip = die;
            audio.Play();
            PersistentData.totalDeaths += 1;
            sceneTransition.GetComponent<SceneTransition>().Die();
        }
        else if (other.CompareTag("Goal"))
        {
            audio.clip = door;
            audio.Play();
            sceneTransition.GetComponent<SceneTransition>().Win();
        }
    }
    public void Win()
    {
        audio.clip = door;
        audio.Play();
        sceneTransition.GetComponent<SceneTransition>().Win();
    }
}
