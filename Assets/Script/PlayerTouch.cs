/**
 * This code is make by Oscar Mo
 * This code is handle the touch position and send position information to the player
 * */

using UnityEngine;
using System.Collections;

public class PlayerTouch : MonoBehaviour {
	
	private int touchCount = 0;
	private Transform objectTrans, cameraTrans;
	private Vector3 fingerTouch = Vector3.zero;

	
	#region Public property
	public int TouchCount
	{
		get 
		{
			return this.touchCount;
		}
	}
	
	public Vector3 FingerTouch
	{
		get
		{
			return this.fingerTouch;
		}
	}
	#endregion
	
	// Use this for initialization
	void Start () {
		objectTrans = this.transform;
		cameraTrans = Camera.main.transform;
	}
	
	void MoveFollowTouch()
	{
		Vector3 temTrans = new Vector3 (Input.GetTouch(touchCount).position.x, Input.GetTouch(touchCount).position.y,
			objectTrans.position.z - cameraTrans.position.z);
		
		fingerTouch = Camera.main.ScreenToWorldPoint(temTrans);
	}
	
	
	void ObjectTouchMove()
	{
		this.SendMessage("TouchMove");
		this.SendMessage("Fire");
		MoveFollowTouch();
	}
	
	void ObjectTouchStay()
	{
		this.SendMessage("TouchMove");
		this.SendMessage("Fire");
		MoveFollowTouch();
	}
	
	void ObjectTouchBegan()
	{	
		touchCount = TouchLogic.currentTouch;
		this.SendMessage("Fire");
	}
	
	void ObjectTouchEnd()
	{
		this.SendMessage("Fire");
	}
	
	
	
	
}
