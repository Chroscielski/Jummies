using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;

// TODO: Player Weapon Attack

public class HeroController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 300.0f;
    [SerializeField] private float movementSpeed = 10.0f;

    [SerializeField]
    [Tooltip("DO NOT CHANGE. Russians Invasion Button")]
    public bool canJump = true;

    public Animator AnimatorController;

    public void Rotate(float xAxis, float yAxis)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(xAxis, 0, yAxis), Vector3.up);
    }

    public void Move(float xAxis, float yAxis)
    {
        Vector3 direction = new Vector3(xAxis, 0, yAxis);
        Vector3 desiredVelocity = direction*movementSpeed;
        desiredVelocity.y = rigidbody.velocity.y;
        rigidbody.velocity = desiredVelocity;
        AnimatorController.SetFloat("SpeedForward", Vector3.Dot(direction, transform.forward));
        AnimatorController.SetFloat("SpeedStrafe", Vector3.Dot(direction, transform.right));
    }

    public void Jump()
    {
        if (canJump)
        {
            canJump = false;
            rigidbody.AddForce(Vector3.up*jumpForce);
            AnimatorController.SetBool("Jumping", true);
        }
    }

    public void AttackUpDown()
    {
        AnimatorController.SetTrigger("AttackUpDown");
    }

    public void AttackSide()
    {
        AnimatorController.SetTrigger("AttackSide");
    }

    public void OnLanded()
    {
        canJump = true;
        AnimatorController.SetBool("Jumping", false);
    }

    public void TakeHit(Vector3 fromVector3)
    {
        fromVector3 = new Vector3(fromVector3.x,0.0f,fromVector3.z);
        Vector3 myTmpVector3 = new Vector3(transform.position.x, 0, transform.position.z);
        rigidbody.AddForce((myTmpVector3 - fromVector3)*100.0f);
        rigidbody.AddForce(Vector3.up * 150.0f);
    }
}
