using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{

    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timerUI;
    public GameObject ScoreUI;

    private void Start()
    {
        Player_Data_Mangement.dataMangement.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerUI.gameObject.GetComponent<Text>().text = ("Time: " + (int)timeLeft);
        ScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
		{
            SceneManager.LoadScene("Prototype_0");
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.gameObject.name == "EndLevel")
		{
            CountScore();
            Player_Data_Mangement.dataMangement.SaveData();
        }
        if(collision.gameObject.name == "Coin")
		{
            playerScore += 10;
            Destroy(collision.gameObject);
		}
	}

    void CountScore()
	{
        playerScore = playerScore + (int)(timeLeft * 10);
        Player_Data_Mangement.dataMangement.highScore = playerScore + (int)(timeLeft * 10);
        Player_Data_Mangement.dataMangement.SaveData();
    }

}
