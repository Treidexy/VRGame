using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Transform cam;

    public Vector3 velocity;

    public float speed = 6.9f;

    [Range(0, 1)]
    public float speedDamp = 0.69f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton((int) MouseButton.LeftMouse) && GameManager.countGVRClick)
            Move(cam.forward);

        rb.velocity = velocity;
        velocity = Vector3.Lerp(velocity, Vector3.zero, speedDamp);
    }

    private void Move(Vector3 dir)
    {
        velocity += dir * speed;
    }
}
