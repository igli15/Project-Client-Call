using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

	/*[SerializeField] 
	private KeyCode skipButton;
	
	
	[SerializeField] 
	private KeyCode skipButton2;*/

	private const float maxTimeNeededToCompleteLoad = 0.9f;
	
	// Use this for initialization
	void Start () 
	{
		
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			LoadLevel("MainMenu");
		}
	}

	public void LoadLevel(string levelName)
	{
		StartCoroutine(LoadLevelAsync(levelName));    //Start out Async Loading
	}

	IEnumerator LoadLevelAsync(string levelName)     //Coroutine allows to load the level without disturbing the main thread.
	{
		/*yield return new WaitForSeconds(1);         // if you want to load slowly */

		AsyncOperation sceneLoadingData = SceneManager.LoadSceneAsync(levelName);   //Get the data and load async
		
		sceneLoadingData.allowSceneActivation = false;           //Don't automatically go to the next level if finished

		while (!sceneLoadingData.isDone)
		{
			if (sceneLoadingData.progress >= maxTimeNeededToCompleteLoad) //If we are completed check If specified buttons are pressed and then go to next scene
			{
				Debug.Log("press any key to continue");
				if (Input.anyKeyDown)
				{
					sceneLoadingData.allowSceneActivation = true;
				}
			}
			yield return null;
		}
	}
}
