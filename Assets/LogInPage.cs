using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogInPage : MonoBehaviour {
	public InputField mainFiedInput;
	public QA[] ReplyWithAnswer;
	public GameObject psd_Invalid;
	// Use this for initialization
	void Start () {
		psd_Invalid.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Post(){
		
		Match ();
	
	}

	//find the match for the replys
	public void Match()
	{
		string inputText = mainFiedInput.text.ToLower();
		for (int i = 0; i < ReplyWithAnswer.Length; i++) {
			int matchcount = 0;
			for (int j = 0; j < ReplyWithAnswer [i].Typed.Length; j++) {
				if (inputText.Contains (ReplyWithAnswer [i].Typed [j].ToLower())) {
					matchcount++;
				}

			}
			if (matchcount == ReplyWithAnswer [i].Typed.Length) {

				if (ReplyWithAnswer [i].Reply == "password") {
					SceneManager.LoadScene (1);
				}
			} else {
				psd_Invalid.SetActive (true);
			}
		}
	}
}
