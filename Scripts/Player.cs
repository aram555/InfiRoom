using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Joystick")]
    public Joystick joystick;
    [Header("Movement")]
    public float speed;
    public float horizontal;
    public float vertical;
    public Transform orientation;
    [Header("Jump")]
    public float jumpSpeed;

    Rigidbody rb;
    Vector3 moveDir;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        int index = PlayerPrefs.GetInt("Index");
        anim = transform.GetChild(index).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0 && rb.velocity.z != 0) anim.Play("Run");
        if(rb.velocity.x == 0 && rb.velocity.z == 0) anim.Play("Idle");
        if(rb.velocity.y != 0) anim.Play("Jump");
    }

    private void FixedUpdate() {
        JoystickMove();
    }

    void JoystickMove() {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        // rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
        // transform.LookAt(transform.position + rb.velocity);
        moveDir = orientation.forward * vertical + orientation.right * horizontal;
        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
        rb.AddTorque(transform.up * 10f * (horizontal - vertical));
    }

    public void Jump() {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
        anim.Play("Jump");
    }
}
