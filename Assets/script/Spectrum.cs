using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Spectrum : MonoBehaviour {
	public float[] spectrum;
	public GameObject obj = null;
	private int 		num 		=  1024;
	public float 		margin 		=  1;
	public float		offset_size = 10;
	
	private GameObject[] clone;
	private Vector3 size  = Vector3.zero;
	private int count = 0;
	
	// Use this for initialization
	void Start () {
		audio.clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す
		audio.loop = true;                                      // ループ再生にしておく
		audio.mute = true;                                      // マイクからの入力音なので音を流す必要がない
		while (!(Microphone.GetPosition("") > 0)){}             // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
		audio.Play(); 

		size = obj.transform.localScale;
		spectrum = new float[num];
		clone = new GameObject[num];
		for(int i = 0; i < num; i++){
			clone[i] = (GameObject)GameObject.Instantiate(obj);
			clone[i].transform.position = new Vector3(margin*i+transform.position.x,transform.position.y,transform.position.z);
			clone[i].transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		spectrum = audio.GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);

		for(int i=0;i<num;i++){
			clone[i].transform.localScale = new Vector3(1,spectrum[i]*offset_size,1);
		}
	}
}
