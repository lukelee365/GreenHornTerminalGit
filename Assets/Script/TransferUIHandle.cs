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
		} else {
			invalidPsd.SetActive (true);
		}
	}

	public void ShowPasswordPage(){
		//2 means everthing End
		if(dialogueO.progressID == 2){
			step1.SetActive (true);
			dialogueO.progressID++;
		}

	}

    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds((float)3.8);
        breachSound.Play();

    }
    IEnumerator CloseStep2(){
		//control the sexy bal
		ballStatus.destColor = new Color (161,0,0);
		ballStatus.anim.SetBool ("SecurityBreach",true);
		yield return new WaitForSecondsRealtime (closeTime);
		step2.SetActive (false);
		ballStatus.destColor = new Color (0,108,161);
		ballStatus.anim.SetBool ("SecurityBreach",false);
		StartCoroutine (chatText.ShowChat ("end"));
	}

}
