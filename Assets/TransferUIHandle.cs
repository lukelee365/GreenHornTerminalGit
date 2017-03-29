using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransferUIHandle : MonoBehaviour {
	private ChatTextFilled chatText;
	public InputField ui_Psd;
	public GameObject step1; 
	public GameObject step2;
    public AudioSource breachSound;
    public float closeTime = 8f;
	public GameObject invalidPsd;
	// Use this for initialization
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
		invalidPsd.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void post(){
		
		if (ui_Psd.text == "31478") {

			step1.SetActive (false);
			step2.SetActive (true);
            StartCoroutine(DelaySound());
            StartCoroutine(CloseStep2 ());
		} else {
			invalidPsd.SetActive (true);
		}
	}

    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds((float)3.8);
        breachSound.Play();

    }
    IEnumerator CloseStep2(){
		yield return new WaitForSecondsRealtime (closeTime);
		step2.SetActive (false);
		StartCoroutine (chatText.ShowChat ("end"));
	}

}
