using UnityEngine;
using System.Collections;

public class FinishLineV2 : MonoBehaviour 
{
	public bool checkPoint = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("checkPoint")) 
		{
			checkPoint = true;
		}
		if (other.gameObject.CompareTag ("finishLine") && checkPoint == true) 
		{
			Application.LoadLevel("menu");
		}
	}
}
