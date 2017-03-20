using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchTheCode : MonoBehaviour {
	public InputField mainFiedInput;

	// Use this for initialization
	void Start () {
		
	}
	public void Match(string txt){

		if (mainFiedInput.text.ToLower() == txt) {
			SceneManager.LoadScene (2);
		
		}
	}


}
