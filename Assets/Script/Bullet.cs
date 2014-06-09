using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public enum Type
	{
		Stationary=0, MachineGun=1, Plasma=2, Laser=3
	}
	
	
	
	public GameObject player;
	/**
	 * the Speed defind the bullet how fast can fly
	 * the Range defind the bullet how far can reach
	 * the Power defind the power of the bullet
	 **/
	public float Speed=0f; 
	public float Range=0f;
	public string BulletName; // name of the bullet
	/**
	 *  the serial of the bullet type: 
	 * 0 -> stationary, 1 -> machine gun, 2 -> plasma, 3 -> laser
	 */
	public int TypeFlag = 0;
	public GameObject Explosion;
	
	
	Type type {get; set;}
	Transform bTran;
	private float distence;
	private Vector3 oldPos;

	
	void Start () {
		bTran = transform;
		oldPos = bTran.position;
		type = Type.Stationary;
		player = GameObject.FindGameObjectWithTag("Player");
		TypeFlag = (int)Type.Stationary;
	}
	
	public void Shoot(Type type)
	{
		//Debug.Log("I am shooting");
		
		//Check the type of the weapon
		if(type==Type.MachineGun || type==Type.Plasma){

		}else if (type==Type.Laser)
		{
			//laser weapon shoot a shaft
		}
	}
	
	
	
}

