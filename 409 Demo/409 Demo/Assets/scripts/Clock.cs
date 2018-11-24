using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
	public GunScript gun;
	public Text gui;
	string display;
	float time;
	public Movement drive;
	private int rammed;
	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		display = "Time: " + ((int)(time+Time.timeSinceLevelLoad+.5)-(gun.getHit()*5)-(rammed*3))+" Ammo: "+(gun.getAmmo().ToString());
		gui.text = display;
	}
	void OnTriggerEnter(Collider other)
	{

			other.gameObject.SetActive (false);
			rammed++;
	
		

	}
	}
