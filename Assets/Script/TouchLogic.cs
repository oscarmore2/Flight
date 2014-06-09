using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {
	
	public static int currentTouch = 0;
	private Ray ray;
	private RaycastHit rayinfo = new RaycastHit();
	private GameObject player;
	
	public bool hit = false;
	
	
	public RaycastHit Rayinfo
	{
		get{
			return this.rayinfo;
		}
	}
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touches.Length > 0)
		{
			for (int i=0; i<Input.touchCount; i++)
			{
				currentTouch = i;
				hit =  Physics.Raycast(ray, out rayinfo);
				
				//the touch move on the Gui
				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					if (Input.GetTouch(i).phase == TouchPhase.Began)
					{
						this.SendMessage("OnTouchBegan");
					}
					
					else if (Input.GetTouch(i).phase == TouchPhase.Moved)
					{
						this.SendMessage("OnTouchMove");
					}
					
					else if (Input.GetTouch(i).phase == TouchPhase.Stationary)
					{
						this.SendMessage("OnTouchStay");
					}
					
					else if (Input.GetTouch(i).phase == TouchPhase.Began)
					{
						this.SendMessage("OnTouchEnd");
					}
				}
				
				
			
				
				//the touch on anywhere on the screen
				if (Input.GetTouch(i).phase == TouchPhase.Began)
				{
					this.SendMessage("TouchAnywhereBegan");
					if (Physics.Raycast(ray, out rayinfo) && rayinfo.transform.gameObject.tag == "Player")
					{
						rayinfo.transform.gameObject.SendMessage("ObjectTouchBegan");
					}
				}
				
				if (Input.GetTouch(i).phase == TouchPhase.Moved)
				{
					this.SendMessage("TouchAnywhereMove");
					player.SendMessage("ObjectTouchMove");
				}
				
				if (Input.GetTouch(i).phase == TouchPhase.Stationary)
				{
					this.SendMessage("TouchAnywhereStay");
					player.SendMessage("ObjectTouchStay");
				}
				
				if (Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					this.SendMessage("TouchAnywhereEnd");
					if (Physics.Raycast(ray, out rayinfo) && rayinfo.transform.gameObject.tag == "Player")
					{
						rayinfo.transform.gameObject.SendMessage("ObjectTouchEnd");
					}
				}
				
			}
			
		}
		
	}
	
	void TouchAnywhereBegan()
	{
		
	}
	
	void TouchAnywhereMove ()
	{
		
	}
	
	void TouchAnywhereStay ()
	{
		
	}
	
	void TouchAnywhereEnd ()
	{
		
	}
}
