using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	public float speed = 0.5f;
	private Vector3 MoveEulerAngles;
	private Vector3 CurrentEulerAngles;

	// Use this for initialization
	void Start () {
		CurrentEulerAngles = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		MoveEulerAngles = CurrentEulerAngles;
		//Debug.Log(MoveEulerAngles);
		transform.Rotate(-(Vector3.up) * Time.deltaTime * speed);
	}
}
