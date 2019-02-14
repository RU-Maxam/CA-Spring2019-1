using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global{
	public static int countPlayer1;
	public static int countPlayer2;
}

public class CountDown : MonoBehaviour{

	[SerializeField] private Text uiText;
	[SerializeField] private float mainTimer;

	public float timer;//what will actually be used as a countdown
	private bool canCount = true;
	private bool doOnce = false;

	void Start(){
		timer = mainTimer;
		winText.text = "";
		totalGemCount = 13;
	}

	void Update(){
		if(timer >= 0.0f && canCount){
			DidGameEnd();
			timer -= Time.deltaTime;
			uiText.text = timer.ToString("F");//timer is a float conveted to a string 
			
		}else if(timer <= 0.0f && !doOnce){
			DidGameEnd();
			canCount = false;
			doOnce = true;
			uiText.text = "0.00";
			timer = 0.0f;
		}
	}
	public void RestartTimer(){
		canCount = true;
		doOnce = false;
		timer = 120.0f;
		uiText.text = timer.ToString("F");
	}

	//Goal: total gems compared to global count gems from player 1 and player 2
	public int totalGemCount;
	public Text winText;
	public void DidGameEnd(){
		Debug.Log("THIS FUNCTION IS GOING");
		
		if(totalGemCount <= Global.countPlayer1+Global.countPlayer2){
			//set text of winner
			if(Global.countPlayer1>Global.countPlayer2){
				winText.text = "Player 1 Win!";
			}else if(Global.countPlayer2>Global.countPlayer1){
					winText.text = "Player 2 Win!";
				}else if(Global.countPlayer1==Global.countPlayer2){
						winText.text = "Wow its a tie!";
				}
			}else if(timer<=0.0f){
			if(Global.countPlayer1>Global.countPlayer2){
				winText.text = "Player 1 Win!";
			}else if(Global.countPlayer2>Global.countPlayer1){
					winText.text = "Player 2 Win!";
				}else if(Global.countPlayer1==Global.countPlayer2){
						winText.text = "Wow its a tie!";
				}
			}
			else{
				//game did not end yet
			//winText.text = "Player 1 Win!";
			}
	}

}