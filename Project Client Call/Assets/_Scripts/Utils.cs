using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Use this script to store static methods that need to be used in multiple places but are not specific to any other script!
//So no dependencies should be introduced in this script!
//No references to any other component as well!

public static class Utils
{
	public static float Find360Angle(Vector3 vec1, Vector3 vec2) //Returns an angle in 360 degree instead of unity's stupid way.
	{
		float angle = Vector3.Angle(vec1, vec2);
		return (Vector3.Angle(Vector3.up, vec2) > 90f) ? 360f - angle : angle;  
	}
	
	public static  Vector2 Vector2FromAngle(float a)
	{
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}
}
