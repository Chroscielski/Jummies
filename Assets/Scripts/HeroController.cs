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

    [SerializeField]
    public AudioClip[] punches;

    public Collider weaponCollider;

    public Animator AnimatorController;
    private float ControllLossAfterHit = 6.0f;

    public float _powerJumpTimeout = 0;
    private float _superHitTimeout = 0;

    public bool PowerAttack = false;

    public int PlayerId;

    public void PlayPunchSound()
    {
        audio.clip = punches[UnityEngine.Random.Range(0, punches.Length-1)];
        audio.Play();
    }

    private float JumpForce
    {
        get { return GameManager.JumpForce * (_powerJumpTimeout > Time.time ? GameManager.JumpForceModifier : 1); }
    }

    private float HitForce
    {
        get { return GameManager.HitForce * (_superHitTimeout > Time.time ? GameManager.SuperHitModifier : 1); }
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

    public IEnumerator EnableWeapon(float duration)
    {
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(duration);
        weaponCollider.enabled = false;
    }

    public void AttackUpDown()
    {
        PowerAttack = true;
        AnimatorController.SetTrigger("AttackUpDown");
        StartCoroutine(EnableWeapon(1));
    }

    public void AttackSide()
    {
        PowerAttack = false;
        AnimatorController.SetTrigger("AttackSide");
        StartCoroutine(EnableWeapon(0.7f));
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

    private float lastHit = 0;
    public void TakeHit(Vector3 fromVector3, float multiplier)
    {
        if (lastHit + 0.2f > Time.time) return;
        canJump = false;
        lastHit = Time.time;
        fromVector3 = new Vector3(fromVector3.x, 0.0f, fromVector3.z).normalized;
        controlModifier = 0;
        rigidbody.AddExplosionForce(HitForce, new Vector3(fromVector3.x, rigidbody.position.y, fromVector3.z), 0, 0);
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