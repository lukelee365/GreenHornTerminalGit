using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;  
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private int level = 3;                                  //Current level number, expressed in game as "Day 1".
	[HideInInspector]
	public string notes;
	[HideInInspector]
	public int process;
	[HideInInspector]
	public int sceneID;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (gameManager == null)

			//if not, set instance to this
			gameManager = this;

		//If instance already exists and it's not this:
		else if (gameManager != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);


		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	public void SaveData(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath +"/playerInfo.dat",FileMode.OpenOrCreate);
		Debug.Log (notes);
		PlayerStatistics data = new PlayerStatistics (sceneID,notes,process);
		bf.Serialize (file, data);
		file.Close ();
	}

	public void LoadData(){
		
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath+"/playerInfo.dat",FileMode.Open);
	
			PlayerStatistics data = (PlayerStatistics)bf.Deserialize (file);
			sceneID = data.SceneID;
			notes = data.NotePad;
//			Debug.Log (data.NotePad+"SceneID"+sceneID);
			process = data.Process;
			file.Close();


		}
	}
	public void CleanData(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath +"/playerInfo.dat",FileMode.Open);
		PlayerStatistics data = new PlayerStatistics (0,null,0);
		bf.Serialize (file, data);
		file.Close ();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
		LoadData();

	}



	//Update is called every frame.
	void Update()
	{

	}
}
[System.Serializable]
public class PlayerStatistics
{
	public int SceneID;
	public string NotePad;
	public int Process;

	public PlayerStatistics(int s, string text, int process){
		SceneID = s;
		NotePad = text;
		Process = process;
	}
}
