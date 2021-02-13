using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatVariable speed;

    [HideInInspector] public Vector3 move;

    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed.value = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        move = transform.right * x + transform.up * y;
        move *= speed.value;

        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);

        rb.velocity = move;
    }
}
