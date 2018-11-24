using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraControlls : MonoBehaviour {
	public GameObject car;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position-car.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = car.transform.position+car.transform.up*30 + Vector3.up*15;
		Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, Quaternion.LookRotation (car.transform.position-transform.position), 60f*Time.deltaTime);
		transform.position = Vector3.Lerp (transform.position, targetPos, 60f*Time.deltaTime);
	}
}
