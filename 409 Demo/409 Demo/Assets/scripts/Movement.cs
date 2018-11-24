using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	[SerializeField] public float acceleration;
	[SerializeField] private float torque;
	//public GameObject obj;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		acceleration = 20f;
		torque = 20f;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//obj.rigidbody.AddForceAtPosition(transform.right*10,transform.position);

		if(Input.GetAxis("Vertical")>0)
		{
			//Movement car forard in terms of direction
			rb.AddRelativeForce (Vector3.down*acceleration);
		}
		if(Input.GetAxis("Vertical")<0)
		{
			//Movement car forard in terms of direction
			rb.AddRelativeForce (Vector3.down*-1*acceleration);
		}
		if(Input.GetAxis("Horizontal")<0)
		{
			//rotate left
			rb.AddRelativeTorque (Vector3.forward*-1*torque);
		}
		if(Input.GetAxis("Horizontal")>0)
		{
			//rotate right
			rb.AddRelativeTorque (Vector3.forward*torque);
		}
		if(Input.GetKey(KeyCode.Space))
		{
			rb.AddRelativeTorque(Vector3.right*2000f);
		}
	}
}