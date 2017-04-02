using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class need work with autoScrollDown,GetTextInput ChatTextFilled and PrigressTextFilled 
public class AutoScrollDown : MonoBehaviour {
	public ScrollRect sR_Chat;
	public ScrollRect sR_Progress;
	public ScrollRect sR_Notes;
	public RectTransform rT_Chat;
	public RectTransform rT_Progress;
	public RectTransform rT_Notes;

	// Use this for initialization
	void Start () {
		if (sR_Notes != null) {
			sR_Notes.verticalNormalizedPosition = 0;
			//sR_Notes.velocity = new Vector2 (0f, 500f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChatScroll(){
		// When the content expand lage enough to have scrroll ball Auto Scroll it
		if (rT_Chat.sizeDelta.y > 450) {
			Canvas.ForceUpdateCanvases ();
			// add spped to scroll bar
			sR_Chat.velocity = new Vector2 (0f, 500f);
			Canvas.ForceUpdateCanvases ();
		}
	}
	public void NotePanelScroll(){
		// When the content expand lage enough to have scrroll ball Auto Scroll it
		if (rT_Notes.sizeDelta.y > 950) {
			Canvas.ForceUpdateCanvases ();
			// add spped to scroll bar
//			sR_Notes.velocity = new Vector2 (0f, 500f);
			//Try this for now
			sR_Notes.verticalNormalizedPosition = 0;
			Canvas.ForceUpdateCanvases ();
		}
	}
	public void ProgressScroll(){

			Canvas.ForceUpdateCanvases ();
			sR_Progress.velocity = new Vector2 (0f, 500f);
			sR_Progress.verticalNormalizedPosition = 0;
			Canvas.ForceUpdateCanvases ();

	}

}
