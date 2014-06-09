using UnityEngine;
using System.Collections;

public class Spiral : MonoBehaviour
{
	
	public Transform target;
	
	public float degree;
	public float xFactor,yFactor;
	// Use this for initialization
	
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		transform.Translate(Time.deltaTime*xFactor,Time.deltaTime*yFactor,0);
		transform.RotateAround(target.position,Vector3.up,degree*Time.deltaTime);
		
	}
}
