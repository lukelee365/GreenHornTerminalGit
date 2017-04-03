using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStatus : MonoBehaviour {

	public GameObject sexyBall;
	public float rotationgSpeed = 15;
	public Light Dlight;
	public Color destColor;
	public float changingColorSpeed=0.0001f;
	public Animator anim;
	// Use this for initialization
	void Start () {
		//Dlight.color = destColor;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up*Time.deltaTime*rotationgSpeed);

		BallColorChange(destColor);
	}

//	void BallStatusLevel1ToLevel2(){
//		Dlight.color = new Color()
//	}
//
//	void BallStatusLevel2ToLevel3(){
//		
//	}
//
//	void BallStatusLevel3ToLevel2(){
//		
//	}
//
//	void BallStatusLevel2ToLevel1(){
//
//	}
	/// <summary>
	/**
	/// Level 1 = blue 
	-    R 0
	-    G 108
	-    B 161

	Level 2 = Green
		-    R 39
		-    G 161
		-    B 0

		Level 3 =  Red
		-    R 161
		-    G 0
		-    B 0
		**/
	/// </summary>
	/// <param name="dest">Destination.</param>
	void BallColorChange(Color dest){

		float r = Dlight.color.r;
		float g = Dlight.color.g;
		float b = Dlight.color.b;
		if (r <= dest.r) {
			r+=changingColorSpeed;
		} else {
			r-=changingColorSpeed;
		}
		if (g<= dest.g) {
			g+= changingColorSpeed;
		} else {
			g-= changingColorSpeed;
		}
		if (b<= dest.b) {
			b+=changingColorSpeed;
		
		} else {
			b-=changingColorSpeed;
		}

		Dlight.color = new Color(r,g,b);
	}
}
