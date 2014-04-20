using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class volume : MonoBehaviour {

	public float vol = 0f;
	public float max = 1f;
	public float min = 1f;

	private float result = 0;
	// Use this for initialization
	void Start () {
		audio.clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す
		audio.loop = true;                                      // ループ再生にしておく
		audio.mute = true;                                      // マイクからの入力音なので音を流す必要がない
		while (!(Microphone.GetPosition("") > 0)){}             // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
		audio.Play();  
	}
	
	void Update()
	{
		vol = GetAveragedVolume();
		print(vol);    
	}
	
	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		audio.GetOutputData(data,0);

		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}

		result = a / 256;

		if(a > max){
			max = a;
		}
		if(a < min && min != 0){
			min = a;
		}

		return result;
	}
}
