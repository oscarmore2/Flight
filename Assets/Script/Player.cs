using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerTouch))]
public class Player : MonoBehaviour {

	enum Status
	{
		playing,
		invisable,
		dead
	}

	public static int Score;
	public static int BombCount = 0;
	public GameObject Bullet;
	public float KeyControlSpeed = 10f;
	public float TouchControlSpeed = 100f;
	public float MaxRotateAngel = 45;
	//public GameObject bullet;
	public float RotateSpeed = 20f;
	
	
	
	private PlayerTouch playerTouch;
	private float maxLeft = 47f;
	private float maxRight = -48f;
	private float maxTop = 85f;
	private float maxButton = -68f;
	private Status playerStatus;
	private Vector3 CurrentAngel;
	private Vector3 TargetAngel;
	private float nextShoot = 0f;
	private float angle = 0f;
	private float lastspeed = 0f;
	private float ShootRate = 0f;
	
	float moveHorizontal = 0;
	float moveVertical = 0;
	
	private float MoveX = 0;
	private float MoveY = 0;
	
	public Vector2 lastPos = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		Player.Score = 0;
		playerStatus = Status.playing;
		transform.position = new Vector3 (0, -50, 150);
		transform.eulerAngles = Vector3.zero;
		playerTouch = this.GetComponent<PlayerTouch>();
		CurrentAngel = transform.eulerAngles;
		TargetAngel = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerStatus == Status.playing)
		{
			if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
				KeyMove(ref lastPos.x, ref lastPos.y);
			
			//Handle the Ship roatation when moving vertical
			angle = Mathf.Clamp(((Mathf.Lerp(lastspeed, MoveX - lastPos.x, Time.deltaTime * 1)) * 20f), -(MaxRotateAngel), MaxRotateAngel) ;
			//Debug.Log ("Turn and angle is "+ angle);
			TargetAngel = new Vector3(0, angle, 0);
			CurrentAngel = Vector3.Lerp(CurrentAngel, TargetAngel, Time.deltaTime * RotateSpeed);
			transform.eulerAngles = CurrentAngel;
			lastspeed = MoveX - lastPos.x;
			
			if (Input.GetKey(KeyCode.Space))
			{
				//Fire();
			}
		}
	}
	
	
	void KeyMove(ref float Horizontal, ref float Vertical)
	{
		moveHorizontal = Input.GetAxis("Horizontal") ;
		moveVertical = Input.GetAxis("Vertical");
		Horizontal = moveHorizontal + transform.position.x;
		Vertical = moveVertical + transform.position.y;
		
		Vector3 pos = new Vector3 (moveHorizontal, moveVertical, 150);
		pos.x  = Mathf.Clamp (pos.x, maxRight, maxLeft);
		pos.y = Mathf.Clamp (pos.y, maxButton, maxTop);
		
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * KeyControlSpeed);
		
	}
	
	void TouchMove()
	{
		MoveX = lastPos.x;
		MoveY = lastPos.y;
		//Debug.Log(playerTouch.FingerTouch);
		Vector3 targetpostion = playerTouch.FingerTouch;
		targetpostion.z = 150f;//lock the distance of the plane
		targetpostion.x = Mathf.Clamp (targetpostion.x, maxRight, maxLeft);
		targetpostion.y = Mathf.Clamp (targetpostion.y, maxButton, maxTop);
		
		transform.position = Vector3.MoveTowards(transform.position, targetpostion, Time.deltaTime * TouchControlSpeed);
		
		lastPos.x = targetpostion.x;
		lastPos.y = targetpostion.y;
		
	}
	
	//The plane goes to fire
	void Fire(GameObject bullet)
	{
		//Debug.Log("I am fire");
		if (Time.time > nextShoot)
		{
			nextShoot = Time.time + ShootRate;
		 	GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			temp.GetComponent<Bullet>().player = gameObject;
		}
	}
	
	public static float HandleAngle(float angle)
	{
		float A=angle;
		
		//If the angle is beyond 360, we need to pull it back to normal angle
		do
		{
			if (A < -360f)
				A += 360f;
			
			if (A > 180)
				A -= 360f;
		} while (A < -360f || A > 360f);
		
		//If the angle is beyond 180, we need to convert it into nagetive angle
		if (A>180f)
			angle = -(180f - (A - 180f));
		
		return (angle);
	}
}
