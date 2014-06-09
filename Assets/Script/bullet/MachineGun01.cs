using UnityEngine;
using System.Collections;

public class MachineGun01 : Bullet {
	private Vector3 startPos;
	
	
	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Type type = new Type();
		type = (Type)GetFlag();
		Shoot(type);
		transform.position += transform.up * Speed * Time.deltaTime * 0.8f;
		transform.RotateAround(startPos, Vector3.forward, 90 * Time.deltaTime);
		transform.position -= transform.forward * Time.deltaTime * 2f;
	}
	
	private int GetFlag()
	{
		return this.TypeFlag;
	}
	
}
