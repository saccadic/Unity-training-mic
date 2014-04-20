using UnityEngine;
using System.Collections;

public class moniter_v2 : MonoBehaviour {
	public Spectrum spec = null;

	private TextMesh text;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
	}

	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<1024;i++){
			text.text += "[" + i + "]" + "=" + spec.spectrum[i].ToString()+"\n";
		}
	}
}
