using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    float slopeAngle = 0f;
    Vector3 slopeNormal;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 회전 방지
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A,D / ←,→
        float v = Input.GetAxisRaw("Vertical");   // W,S / ↑,↓

        Vector3 move = new Vector3(h, 0f, v).normalized * moveSpeed;

        Vector3 newVelocity = new Vector3(move.x, rb.velocity.y, move.z); // y속도 유지
        if(rb.velocity.y > 0f) newVelocity.y = 0f;

        if (slopeAngle != 0f)
        {
            // 평면에 투영
            newVelocity = Vector3.ProjectOnPlane(newVelocity, slopeNormal).normalized * moveSpeed;
            newVelocity.y = rb.velocity.y;
        }
        rb.velocity = newVelocity;

    }

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            slopeNormal = contact.normal;
            slopeAngle = Vector3.Angle(slopeNormal, Vector3.up);
        }
    }
}
