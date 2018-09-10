using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisions : MonoBehaviour
{

	[SerializeField] 
	private Rigidbody2D playerRb;

	private void OnTriggerEnter2D(Collider2D other)
	{
			float angle = Find360Angle(playerRb.transform.right, transform.right);

			if ((angle >= 0 && angle <= 25) || (angle <= 360 && angle >= 335))
			{
				Debug.Log("Forward slash");
			}
			else if (angle > 25 && angle < 80)
			{
				Debug.Log("UpForwardSlash");
			}
			else if (angle >= 80 && angle < 110)
			{
				Debug.Log("UpSlash");
			}
			else if (angle >= 110 && angle < 155)
			{
				Debug.Log("UpBackwardsSlash");
			}
			else if (angle >= 155 && angle < 205)
			{
				Debug.Log("BackwardsSlash");
			}
			else if (angle >= 205 && angle < 245)
			{
				Debug.Log("DownBackwardsSlash");
			}
			else if (angle >= 245 && angle < 305)
			{
				Debug.Log("DownwardsSlash");
			}
			else if (angle >= 305 && angle < 335)
			{
				Debug.Log("ForwardDownSlash");
			}

	}
	
	public float Find360Angle(Vector3 vec1,Vector3 vec2)  //Returns an angle in 360 degree instead of unity's stupid way.
	{
		float angle = Vector3.Angle(vec1,vec2);
		return (Vector3.Angle(Vector3.up, vec2) > 90f) ? 360f - angle : angle;            
	}
}
