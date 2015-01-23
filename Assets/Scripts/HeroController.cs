using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
    public void TakeHit(Vector3 fromVector3)
    {
        Debug.Log("GETTING DAMAGE " + this.gameObject.name);

        fromVector3 = new Vector3(fromVector3.x,0.0f,fromVector3.z);
        Vector3 myTmpVector3 = new Vector3(transform.position.x, 0, transform.position.z);
        this.rigidbody.AddForce((myTmpVector3 - fromVector3)*100.0f);
        this.rigidbody.AddForce(Vector3.up * 150.0f);
    }
}
