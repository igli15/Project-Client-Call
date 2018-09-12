using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour {

	public void Save(PlayerCollisions sender = null)
	{
		var data = JsonUtility.ToJson(this, true);
		File.WriteAllText(Application.persistentDataPath + "/SaveData.json", Encryption.Encrypt(data));
	}
    
	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/SaveData.json"))
		{
			var loadedData = Encryption.Decrypt(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));
			Debug.Log(loadedData);
			JsonUtility.FromJsonOverwrite(loadedData, this);
		}
	}
}
