using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class need work with autoScrollDown,GetTextInput ChatTextFilled, PanelManager and PrigressTextFilled 
public class ChatTextFilled : MonoBehaviour {
	public TextChunk[] textChunks;
	public TextChunk[] WaitingText;
	public float interval;
	public float waitingTime;
	public Text textPanel;
	private ProgressTextFiled progressText;
	private AutoScrollDown autoScroll;
	private float timer;
	private PanelManager pM;
	private DialogueOption dialogueO;
	public GameObject soundManager;
	private bool once;  
	private bool once2;
	public bool once3;
	public GameObject typingTxt;
	private bool once4;
	// Use this for initialization
	void Start () {
		progressText = GetComponent<ProgressTextFiled> ();
		autoScroll = GetComponent<AutoScrollDown> ();
		pM = GetComponent<PanelManager> ();
		dialogueO = GetComponent<DialogueOption> ();
		timer = Time.time+waitingTime;

		once = true;
		once2 = true;
		once3 = true;
		once4 = true;
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
			textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>"+ WaitingText [i].progressTextModular [j] + "</color>";
			autoScroll.ChatScroll ();
		}
	}

	public IEnumerator ShowChat(string chunkName){
		//SearchNameofThetextChunk	
		chunkName = chunkName.ToLower();
		for (int i = 0; i < textChunks.Length; i++) {
			//find the match name of the text Chunk
//			Debug.Log(chunkName);
//			Debug.Log (textChunks.Length);
//			Debug.Log (i);
			if (textChunks [i].name.ToLower() == chunkName) {
				//loop through each text in modular
				//Debug.Log(chunkName);
				if (chunkName == "init") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						
						if (j!= 0) {
							typingTxt.SetActive (true);
						}
						yield return new WaitForSeconds (Random.Range(2,4));
//						if(j==1)
//							typingTxt.SetActive (true);
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						if (j!= 0) {
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						}

						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							dialogueO.EnableDialogueOption(1);
							dialogueO.dialogue_text [0].text = "How can I help ?";


						}
					}
				}else if (chunkName == "emailfirst") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						if (j == 3) { //second Sentnece
							StartCoroutine(progressText.ShowProgress("emailfirst"));
							pM.PanelButtonsObjs [0].SetActive (true);
							pM.BtnInteactAll ("Mail");
							pM.btn_Email.SetActive (true);
							pM.EnablePanel ("Panel_Content_Mail");
						}
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
						
							dialogueO.EnableDialogueOption(2);
							dialogueO.dialogue_text [0].text = "Yes";
							dialogueO.dialogue_text [1].text = "No";
						}
					}
//				} else if (chunkName == "emailsecond") {
//					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
//						yield return new WaitForSeconds (interval);
//						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
//						autoScroll.ChatScroll ();
//						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
//						if (j == textChunks [i].progressTextModular.Length - 1) {
//							//at end
//						
//							//how many buttons need to be enable
//							dialogueO.EnableDialogueOption(2);
//							dialogueO.dialogue_text [0].text = "Yes";
//							dialogueO.dialogue_text [1].text = "No";
//						}
//					}
				}else if (chunkName == "yes") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end

						

						}
					}
				}else if (chunkName == "no") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end

					
						}
					}
				}else if (chunkName == "vance") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end

							//how many buttons need to be enable
							dialogueO.EnableDialogueOption(1);
							dialogueO.dialogue_text [0].text = "Why is he friendly with the folks from Arcadia ?";

						}
					}
				}else if (chunkName == "ipcc") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							//how many buttons need to be enable

							dialogueO.EnableDialogueOption(1);
							dialogueO.dialogue_text [0].text = "Why isn’t Arcadia responding ?";

						}
					}
				}else if (chunkName == "end") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();

						dialogueO.DisableDialogueOption();
					
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							//how many buttons need to be enable

							StartCoroutine(progressText.ShowProgress("emailforth"));
						}
					}
				}else if (chunkName == "offline") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (Random.Range(2,4));
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();

					}
				} else {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						typingTxt.SetActive (true);
						yield return new WaitForSeconds (Random.Range(2,4));
						typingTxt.SetActive (false);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
						soundManager.GetComponent<SoundController> ().PlayArtiemisSound ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//finish all the thing break the loop
							break;
						}
					}
				}
			} 
		}
	}

	void DelaySecondEmail(){
//		Debug.Log("HereLater");
		StartCoroutine(progressText.ShowProgress("emailsecond"));
	}

	public void ShowDialogueAboutVanceOnce(){
		if (once&&(dialogueO.progressID<5)) {
			dialogueO.DisableDialogueOption ();
			dialogueO.EnableDialogueOption (1);
			dialogueO.dialogue_text [0].text = "Who is Vance Kalken ?";
			once = false;
		}
	}
	public void OpenPassWordEmail(){
		if (once2&&(dialogueO.progressID<5)) {
//			Debug.Log ("Password");
			StartCoroutine (ShowChat ("password"));
			once2 = false;
		}
	}


	public void GiveHintAboutTwitter(){

		Debug.Log ("Hint");
		Invoke ("ShowDialogue", 30f);
			

	}

	void ShowDialogue(){
		
		if(once3&&(dialogueO.progressID<5)){
			dialogueO.DisableDialogueOption ();
			dialogueO.EnableDialogueOption (1);
			dialogueO.dialogue_text [0].text = "I'm not sure what to do with this code";
			once3 = false;
		}
	}

	public void OpenIPCCEmail(){
		if (once4&&(dialogueO.progressID<5)) {
			dialogueO.DisableDialogueOption();
			dialogueO.EnableDialogueOption (1);
			dialogueO.dialogue_text [0].text = "What is IPCC ?";
			once4 = false;
		}
	}
}
