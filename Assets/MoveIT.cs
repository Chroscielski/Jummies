using UnityEngine;
using System.Collections;

public class MoveIT : MonoBehaviour
{
    public float moveX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //moveX = Input.GetAxis("Horizontal");

        transform.position = new Vector3(transform.position.x - moveX * 1 * Time.deltaTime,transform.position.y, transform.position.z );
	}
}
