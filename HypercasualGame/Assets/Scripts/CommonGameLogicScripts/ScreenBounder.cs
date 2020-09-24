using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounder : MonoBehaviour
{
	public static Vector2 ScreenBounds { get; private set; }

	private void Awake()
	{
		ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}
}
