using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
	[HideInInspector]
	public float test = 10;
	
	public void Save(object objToSave,string saveFileName)
	{
		var data = JsonUtility.ToJson(objToSave, true);
		File.WriteAllText(Application.persistentDataPath + "/"+ saveFileName + ".json", Encryption.Encrypt(data));
		Debug.Log(Encryption.Encrypt(data));
		
	}
    
	public void Load(string fileNameToLoadFrom,object objToLoad)
	{
		if (File.Exists(Application.persistentDataPath + "/"+ fileNameToLoadFrom + ".json"))
		{
			var loadedData = Encryption.Decrypt(File.ReadAllText(Application.persistentDataPath + "/"+ fileNameToLoadFrom + ".json"));

			JsonUtility.FromJsonOverwrite(loadedData, objToLoad);
			
			Debug.Log(loadedData);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			test += 1;
			Save(this,"Test");
			Load("Test",this);
		}
	}
}
