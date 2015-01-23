using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 300.0f;

    public void Move(float xAxis, float yAxis)
    {
        rigidbody.velocity = new Vector3(xAxis * Time.deltaTime, rigidbody.velocity.y, yAxis * Time.deltaTime);
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce);
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
