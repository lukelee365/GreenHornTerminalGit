using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransferUIHandle : MonoBehaviour {
	private ChatTextFilled chatText;
	public InputField ui_Psd;
	public GameObject step1; 
	public GameObject step2;
	public float closeTime = 8f;
	// Use this for initialization
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void post(){
		
		if (ui_Psd.text.ToLower () == "password") {

			step1.SetActive (false);
			step2.SetActive (true);
			StartCoroutine (CloseStep2 ());
		}
	}

	IEnumerator CloseStep2(){
		yield return new WaitForSecondsRealtime (closeTime);
		step2.SetActive (false);
		StartCoroutine (chatText.ShowChat ("end"));
	}

}
