using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10.0f;

    [SerializeField]
    [Tooltip("DO NOT CHANGE. Russians Invasion Button")]
    public bool canJump = true;

    public Animator AnimatorController;
    private float ControllLossAfterHit = 6.0f;

    public float _powerJumpTimeout = 0;
    private float _superHitTimeout = 0;

    public int PlayerId;

    private float JumpForce
    {
        get { return GameManager.JumpForce * (_powerJumpTimeout > Time.time ? GameManager.JumpForceModifier : 1); }
    }

    private float HitForce
    {
        get { return GameManager.HitForce*(_superHitTimeout > Time.time ? GameManager.SuperHitModifier : 1); }
    }

    private float controlModifier = 1.0f;

    public void Rotate(float xAxis, float yAxis)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(xAxis, 0, yAxis), Vector3.up);
    }

    void Update()
    {
        controlModifier = Mathf.MoveTowards(controlModifier, 1.0f, Time.deltaTime / ControllLossAfterHit);
    }

    public void Move(float xAxis, float yAxis)
    {
        Vector3 direction = new Vector3(xAxis, 0, yAxis);
        Vector3 desiredVelocity = direction * movementSpeed;
        desiredVelocity.y = rigidbody.velocity.y;
        Vector3 currentVelocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        Vector3 setVelocity = Vector3.Lerp(currentVelocity, desiredVelocity, controlModifier);
        setVelocity.y = rigidbody.velocity.y;
        rigidbody.velocity = setVelocity;
        AnimatorController.SetFloat("SpeedForward", Vector3.Dot(direction, transform.forward));
        AnimatorController.SetFloat("SpeedStrafe", Vector3.Dot(direction, transform.right));
    }

    public void Jump()
    {
        if (!canJump) return;
        canJump = false;
        rigidbody.AddForce(Vector3.up * JumpForce);
        AnimatorController.SetBool("Jumping", true);
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

    public void OnDeath()
    {
        LevelManager.OnPlayerDeath(PlayerId);
        Destroy(gameObject);
    }

    public void TakeHit(Vector3 fromVector3)
    {
        fromVector3 = new Vector3(fromVector3.x, 0.0f, fromVector3.z).normalized;
        controlModifier = 0;
        rigidbody.AddExplosionForce(HitForce, new Vector3(fromVector3.x, rigidbody.position.y, fromVector3.z), 0, GameManager.HitForce / 5);
    }

    public void EnablePowerJump(float time)
    {
        _powerJumpTimeout = Time.time + time;
    }

    public void EnableSuperHit(float time)
    {
        _superHitTimeout = Time.time + time;
    }
}