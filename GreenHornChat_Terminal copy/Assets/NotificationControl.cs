using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NotificationControl : MonoBehaviour {
	[HideInInspector]
	private int numOfNotification;
	public GameObject notification;
	public Text textNotification;
	public GameObject[] mailBeenReaded; //The BG of Each Email Panel
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (numOfNotification <= 0) {
			notification.SetActive (false);
		} else {
			int temp = 0;
			foreach(GameObject objs in mailBeenReaded){
				if (objs.activeSelf == true) {
					temp++;
				} 
			}
			numOfNotification = temp;
			textNotification.text = numOfNotification.ToString();
			notification.SetActive (true);
		}

	}
		

	public void AddNotification(int num){
		numOfNotification += num;
	}
}
