﻿using System.Collections;
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
	private DialogueOption dialogueO;
	public BallStatus ballStatus;
	// Use this for initialization
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
		dialogueO = GetComponent<DialogueOption> ();
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
			if (dialogueO.progressID == 1) {
				dialogueO.progressID = 5;
			}
		} else {
			invalidPsd.SetActive (true);
		}
	}

	public void ShowPasswordPage(){
		//5 means everthing End
		if(dialogueO.progressID == 1){
			step1.SetActive (true);
		}

	}

    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds((float)3.8);
        breachSound.Play();

    }
    IEnumerator CloseStep2(){
		//control the sexy bal
		ballStatus.BallStatus3();
		ballStatus.anim.SetBool ("SecurityBreach",true);//ball color turn red, animation happeing
		yield return new WaitForSecondsRealtime (closeTime);
		step2.SetActive (false);

		StartCoroutine (chatText.ShowChat ("end"));
	}

}
