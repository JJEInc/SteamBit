using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour {

	public static void SaveGame(SavePoint aSavePoint)
	{
		if (!Directory.Exists("SaveFiles"))
            Directory.CreateDirectory("SaveFiles");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("SaveFiles/save.binary");
        //FileStream SaveObjects = File.Create("SaveFiles/saveObjects.binary");

        //LocalCopyOfData = PlayerState.Instance.localPlayerData;

        formatter.Serialize(saveFile, GameManager.saveLoadData);
        //formatter.Serialize(SaveObjects, SavedLists);

        saveFile.Close();
        //SaveObjects.Close();

        print("Saved Successful!");
	}

	public static void LoadGame()
	{
		BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

		GameManager.saveLoadData = (SaveLoadData)formatter.Deserialize(saveFile);

        SetupGame();
        
        saveFile.Close();

        print("Load Successful!");
	}

	public static void SetupGame()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		player.transform.position = SaveLoadData.savePoint.location.ToVector3();
	}
}
