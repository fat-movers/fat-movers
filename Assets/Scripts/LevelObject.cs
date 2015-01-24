using UnityEngine;
using System.Collections;
using System;

[Serializable]

public class LevelObject{

	public string levelName;
	public string levelSceneName;

	public LevelObject(string newLevelName, string newLevelSceneName){
		levelName = newLevelName;
		levelSceneName = newLevelSceneName;
	}
}
