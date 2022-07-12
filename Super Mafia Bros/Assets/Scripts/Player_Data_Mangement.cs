using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Player_Data_Mangement : MonoBehaviour
{

    public static Player_Data_Mangement dataMangement;
    public int highScore;

	private void Awake()
	{
		if(dataMangement == null)
		{
			DontDestroyOnLoad(gameObject);
			dataMangement = this;
		}
		else if(dataMangement != this)
		{
			Destroy(gameObject);
		}
	}

	public void SaveData()
	{
		BinaryFormatter binForm = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Mafia.dat");
		gameData data = new gameData();
		data.highScore = highScore;
		binForm.Serialize(file, data);
		file.Close();
	}

	public void LoadData()
	{
		if(File.Exists(Application.persistentDataPath + "/Mafia.dat"))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Open(Application.persistentDataPath + "/Mafia.dat", FileMode.Open);
			gameData game = (gameData)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			highScore = game.highScore;
		}
	}

}


[Serializable]
class gameData
{
	public int highScore;
}