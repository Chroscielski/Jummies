using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 300.0f;
    [SerializeField] private float movementSpeed = 10.0f;

    [SerializeField]
    [Tooltip("DO NOT CHANGE. Russians Invasion Button")]
    public bool canJump = true;

    public void Rotate(float xAxis, float yAxis)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(xAxis, 0, yAxis), Vector3.up);
    }

    public void Move(float xAxis, float yAxis)
    {
        rigidbody.velocity = new Vector3(xAxis * movementSpeed * Time.deltaTime, rigidbody.velocity.y, yAxis * movementSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (canJump)
        {
            canJump = false;
            rigidbody.AddForce(Vector3.up*jumpForce);
        }
    }

    public void TakeHit(Vector3 fromVector3)
    {
        Debug.Log("GETTING DAMAGE " + gameObject.name);

        fromVector3 = new Vector3(fromVector3.x,0.0f,fromVector3.z);
        Vector3 myTmpVector3 = new Vector3(transform.position.x, 0, transform.position.z);
        rigidbody.AddForce((myTmpVector3 - fromVector3)*100.0f);
        rigidbody.AddForce(Vector3.up * 150.0f);
    }
}
