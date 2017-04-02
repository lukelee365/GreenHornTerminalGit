using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextChunk{
	public string name;
	public string[] progressTextModular;
}
//This class need work with autoScrollDown,GetTextInput ChatTextFilled and PrigressTextFilled 
public class ProgressTextFiled : MonoBehaviour {

	public TextChunk[] textChunks;
	public float interval;
	public Text textPanel;
	private ChatTextFilled chatText;
	private AutoScrollDown autoScroll;
	public GameObject[] EmailsSet1;
	public GameObject[] EmailsSet2;
	public GameObject[] EmailsSet3;
	public GameObject[] EmailsSet4;

    public GameObject soundManager;
	private NotificationControl notificationC;
	// Use this for initialization
	void Start () {
		chatText = GetComponent<ChatTextFilled> ();
		autoScroll = GetComponent<AutoScrollDown> ();
		notificationC = GetComponent<NotificationControl> ();
		StartCoroutine (ShowProgress ("init"));
		foreach (GameObject objs in EmailsSet1) {
			objs.SetActive (false);
		}
			
		foreach (GameObject objs in EmailsSet2) {
			objs.SetActive (false);
		}
		foreach (GameObject objs in EmailsSet3) {
			objs.SetActive (false);
		}
		foreach (GameObject objs in EmailsSet4) {
			objs.SetActive (false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowProgress(string chunkName){
		//SearchNameofThetextChunk	and show the text in some delay
		chunkName = chunkName.ToLower();
		for (int i = 0; i < textChunks.Length; i++) {
			//find the match name of the text Chunk
		if (textChunks [i].name.ToLower() == chunkName) {
				//loop through each text in modular
				if (chunkName == "init") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();


							
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							StartCoroutine(chatText.ShowChat("init"));
						}
					}
				}else if (chunkName == "emailfirst") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
                            //at end
                            soundManager.GetComponent<SoundController>().NewMessageSound();

							EnableEmailSet (EmailsSet1);
							//StartCoroutine(chatText.ShowChat("emailsecond"));// show the option
							Invoke("DelaySecondEmail",30f);
							Invoke("DelayThridEmail",60f);
							break;
						}
					}
				}else if (chunkName == "emailsecond") {

					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
                            //at end
                            soundManager.GetComponent<SoundController>().NewMessageSound();

                            autoScroll.ProgressScroll ();
							EnableEmailSet (EmailsSet2);

						}
					}
				}else if (chunkName == "emailthird") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							soundManager.GetComponent<SoundController>().NewMessageSound();

							autoScroll.ProgressScroll ();
							EnableEmailSet (EmailsSet3);

						}
					}
				}else if (chunkName == "emailforth") {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ProgressScroll ();
						if (j == textChunks [i].progressTextModular.Length - 1) {
							//at end
							soundManager.GetComponent<SoundController>().NewMessageSound();

							autoScroll.ProgressScroll ();
							EnableEmailSet (EmailsSet4);
							StartCoroutine(chatText.ShowChat("offline"));
						}
					}
				}else {
					for (int j = 0; j < textChunks [i].progressTextModular.Length; j++) {
						yield return new WaitForSeconds (interval);
						textPanel.text = textPanel.text + "\n" + "<color=#2ce7d8>" + textChunks [i].progressTextModular [j] + "</color>";
						autoScroll.ChatScroll ();
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
		StartCoroutine (ShowProgress ("emailsecond"));

		//EnableEmailSet (EmailsSet2);

	}
	void DelayThridEmail(){
		
		StartCoroutine (ShowProgress ("emailthird"));
		//EnableEmailSet (EmailsSet3);
	}


	public void EnableEmailSet(GameObject[] Email){
		foreach (GameObject objs in Email) {
			objs.SetActive (true);

		}
		notificationC.AddNotification (Email.Length);
	}




}
