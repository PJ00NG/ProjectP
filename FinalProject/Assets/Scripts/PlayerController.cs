using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    public CharacterController controller;
    public AudioSource footsteps;

    public float speed = 4f;
    public float gravity = -9.81f;

    public float stamina = 3f;
    public bool isTired = false;

    Vector3 velocity;
    bool isGrounded;
    private bool walk = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if (isGrounded == true && velocity.magnitude > 1f && !GetComponent<AudioSource>().isPlaying && !walk)
            {
                GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
                GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
                GetComponent<AudioSource>().Play();

            }
        }
       
       
       

        //movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (stamina >= 3)
        {
            //isTired = false;
            speed = 4f;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina <= 3)
            {
                stamina += Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina >= 0)
            {
                stamina -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4f;
        }
    }
}
