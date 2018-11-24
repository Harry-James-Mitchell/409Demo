using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour 
{
	public bool reloading = false;
	public int clipSize = 4;
	public float reloadTime = 3f;
	public float range = 50f;
	private RaycastHit shootHit;
	private Ray shootRay = new Ray();
	private float timeElapsed = 0f;
	private int ammo;
	private int numhit;

	void Awake () 
	{

	}

	// Use this for initialization
	void Start () 
	{
		ammo = clipSize;
		numhit = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ammo == 0 || Input.GetButtonDown("reload") || reloading) 
		{
			reload ();
		}
		if(Input.GetButtonDown("Fire1"))
		{
			if(ammo > 0)
			{
				shoot();
			}
		}
	}

	public void reload()
	{
		if (!reloading) 
		{
			reloading = true;
			Debug.Log("Reloading!");
		}
		else
		{
			timeElapsed += Time.deltaTime;
			if(timeElapsed >= reloadTime)
			{
				Debug.Log("Done in " + timeElapsed);
				ammo = clipSize;
				timeElapsed = 0;
				reloading = false;
			}
		}
	}

	//collider must have the tag "target".
	public void shoot()
	{
		ammo--;
		Debug.Log("SHOOT!");
		Debug.Log("ammo left " + ammo);
		shootRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (shootRay, out shootHit, range)) 
		{
			Vector3 targetPos = shootHit.collider.transform.position;
			shootRay.origin = transform.position + transform.forward;
			shootRay.direction = targetPos - shootRay.origin;
			if(Physics.Raycast (shootRay, out shootHit, range))
			{
				if(shootHit.collider.CompareTag("target"))
				{
					Debug.Log("HIT!");
					shootHit.collider.gameObject.SetActive(false);
					numhit++;
				}
			}
		}
	}
	public int getHit(){
		return numhit;
	}
	public int getAmmo(){
		return ammo;
	}
}
