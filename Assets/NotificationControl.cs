using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NotificationControl : MonoBehaviour {
	[HideInInspector]
	private int numOfNotification;
    public GameObject soundManager;
    public GameObject notification;
	public Text textNotification;
    private bool playSound;
    private int oldNumber;
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
            if (temp == 4 && oldNumber != 4)
            {
                oldNumber = 4;
                playSound = true;
            }
            if (playSound)
            {

                soundManager.GetComponent<SoundController>().NewMessageSound();
                playSound = false;
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
