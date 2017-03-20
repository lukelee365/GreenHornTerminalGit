using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class need work with autoScrollDown,GetTextInput ChatTextFilled and PrigressTextFilled 
public class AutoScrollDown : MonoBehaviour {
	public ScrollRect sR_Chat;
	public ScrollRect sR_Progress;
	public RectTransform rT_Chat;
	public RectTransform rT_Progress;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChatScroll(){
		// When the content expand lage enough to have scrroll ball Auto Scroll it
		if (rT_Chat.sizeDelta.y > 240) {
			Canvas.ForceUpdateCanvases ();
			// add spped to scroll bar
			sR_Chat.velocity = new Vector2 (0f, 500f);
			Canvas.ForceUpdateCanvases ();
		}
	}

	public void ProgressScroll(){
		if (rT_Chat.sizeDelta.y > 270) {
			Canvas.ForceUpdateCanvases ();
			sR_Progress.velocity = new Vector2 (0f, 500f);
			Canvas.ForceUpdateCanvases ();
		}
	}

}
