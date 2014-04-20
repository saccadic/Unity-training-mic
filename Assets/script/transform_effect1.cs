using UnityEngine;
using System.Collections;

public class transform_effect1 : MonoBehaviour {
	public volume audio = null; 
	public GameObject obj = null;
	public int 		num 	=  1;
	public float 	margin 	=  0;
	public int 		max 	=  1;
	public int		min 	= -1;
	public float	offset_size = 0;

	private GameObject[] clone;
	private Vector3 size  = Vector3.zero;
	private int count = 0;

	// Use this for initialization
	void Start () {
		size = obj.transform.localScale;
		clone = new GameObject[num];
		for(int i = 0; i < num; i++){
			clone[i] = (GameObject)GameObject.Instantiate(obj);
			clone[i].transform.position = new Vector3(margin*i+transform.position.x,transform.position.y,transform.position.z);
			clone[i].transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(count >= num){
			count = 0;
		}
		size = new Vector3(1f,audio.vol*offset_size,1f);
		clone[count].transform.localScale = size;
		for(int i=0;i<num;i++){
			if(i < count + min || count + max < i){
				clone[i].transform.localScale = new Vector3(1,1,1);
			}
		}
		count++;
	}
}
