using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class QA{
	public string[] Typed;
	public string Reply;
}
//This class need work with autoScrollDown,GetTextInput ChatTextFilled and PrigressTextFilled 
public class GetTextInput : MonoBehaviour {
	public InputField mainFiedInput;
	public Text textPanel;
	public QA[] ReplyWithAnswer;
	private ProgressTextFiled progressText;
	private ChatTextFilled chatText;
	// Use this for initialization
	void Start () {
		progressText = GetComponent<ProgressTextFiled> ();
		chatText = GetComponent<ChatTextFilled> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Post(){
		textPanel.text = textPanel.text+"\n"+"<color=Green>"+"   "+mainFiedInput.text+"</color>";
		Match ();
	    mainFiedInput.text = "";
		chatText.resetTimer ();
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
			if (matchcount == ReplyWithAnswer [i].Typed.Length ) {

				textPanel.text = textPanel.text+"\n"+"<color=#2ce7d8>"+"   "+ReplyWithAnswer[i].Reply+"</color>";
				if (ReplyWithAnswer [i].Reply == "password") {
					SceneManager.LoadScene (1);
				}
			}
		}
	}


}
