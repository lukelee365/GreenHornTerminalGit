using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class need work with autoScrollDown,GetTextInput ChatTextFilled and PrigressTextFilled 
public class ChatTextFilled : MonoBehaviour {
	public TextChunk[] textChunks;
	public TextChunk[] WaitingText;
	public float interval;
	public float waitingTime;
	public Text textPanel;
	private ProgressTextFiled progressText;
	private AutoScrollDown autoScroll;
	private float timer;
	// Use this for initialization
	void Start () {
		progressText = GetComponent<ProgressTextFiled> ();
		autoScroll = GetComponent<AutoScrollDown> ();
		timer = Time.time+waitingTime;
	}
	
	// Update is called once per frame
	void Update () {
		HurryUp ();
	}
	 void HurryUp(){
			if (Time.time > timer) {
				timer = Time.time + waitingTime;
				StartCoroutine (ShowWaitingText ());
			} 
	}

	public void resetTimer(){
		timer = Time.time+waitingTime;
	}
	//randomlize waitingText output
	IEnumerator ShowWaitingText(){
		int i = (int)Random.Range (0, WaitingText.Length);
		for (int j = 0; j < WaitingText [i].progressTextModular.Length; j++) {
			yield return new WaitForSeconds (interval);
			textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + "   " + WaitingText [i].progressTextModular [j] + "</color>";
			autoScroll.ChatScroll ();
		}
	}

	public IEnumerator ShowChat(string chunkName){
		//SearchNameofThetextChunk	
		chunkName = chunkName.ToLower();
		for (int i = 0; i < textChunks.Length; i++) {
			//find the match name of the text Chunk
			if (textChunks [i].name.ToLower() == chunkName) {
				//loop through each text in modular
				for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
					yield return new WaitForSeconds (interval);
					textPanel.text = textPanel.text+"\n"+"<color=#2ce7d8>"+"   "+textChunks [i].progressTextModular [j]+"</color>";
					autoScroll.ChatScroll ();
				}
				progressText.EnableEmails ();
			} else {
				//break the loop
				yield break;
			}
		}
	}
}
