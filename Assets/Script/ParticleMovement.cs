using UnityEngine;
using System.Collections;

public class ParticleMovement : MonoBehaviour {
	public float StartPos = 250f;
	public float EndPos = -200f;
	private Vector3 movePos = Vector3.zero;
	public float MoveSpeed = 5f;

	// Use this for initialization
	void Start () {
		//init the start position
		movePos = new Vector3 (0f, StartPos, 200f);
	}
	
	// Update is called once per frame
	void Update () {
		//make the Object move fram per second and form itself to the target	
		movePos = Vector3.MoveTowards(movePos, new Vector3(0f, EndPos, 200f), Time.deltaTime * MoveSpeed);
		transform.position = movePos;
		//Debug.Log(transform.position + " still moving");

		//if the position come to end, reset the position
		if (transform.position.y == EndPos && transform.position.y != StartPos){
			movePos = new Vector3(0f, StartPos, 200f);
			//Debug.Log(transform.position + " I reach to the end");
		}
		
	}
}
