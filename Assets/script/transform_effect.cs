using UnityEngine;
using System.Collections;

public class transform_effect : MonoBehaviour {
	public volume audio = null; 
	public Vector3 size  = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		size = new Vector3(audio.vol,audio.vol,audio.vol);

		transform.localScale = size*1000;
		transform.Rotate (size);
	}
}
