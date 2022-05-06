using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCollision : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initialPos;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.localPosition;
    }
    private void OnCollisionStay(Collision collision)
    {


        if (collision.gameObject.tag == "Platform")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            float step = collision.gameObject.GetComponent<RotatingPlatform>().speed;
            Vector3 target = transform.localPosition;
            target.x = -2.5f * step * Mathf.Abs(step);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, (Mathf.Abs(step) / 20) * Time.deltaTime);

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {

            rb.constraints = RigidbodyConstraints.None;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.freezeRotation = true;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            transform.localPosition = initialPos;
        }

    }
}
