﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {
	public static WayPoints instance;

	public Transform[] points;
	// Use this for initialization
	void Awake ()
	{
		if (instance != null)
			return;
		
		points = new Transform[transform.childCount];
		for (int i = 0; i < points.Length; i++) 
		{
			points [i] = transform.GetChild (i);
		}

		instance = this;
	}
}
