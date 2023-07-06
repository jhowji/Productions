using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    public float speed;
    public float gravity;
    public float rspeed;

    private float rot;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                anim.SetInteger("tran", 1);
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("tran", 0);
            }
            rot += Input.GetAxis("Horizontal") * rspeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0,rot, 0);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
