﻿using UnityEngine;
using System.Collections;

public class moniter : MonoBehaviour {
	public volume audio = null; 

	private TextMesh text;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = audio.vol.ToString();
	}
}
