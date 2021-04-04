using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonLoader
{
	public void Save(UserData userData) {
		string jsonString = JsonConvert.SerializeObject(userData);
		File.WriteAllText(Application.persistentDataPath + "/userData.json", jsonString);
	}

	public UserData Load() {
		if (File.Exists(Application.persistentDataPath + "/userData.json")) {
			string data = File.ReadAllText(Application.persistentDataPath + "/userData.json");
			UserData userData = JsonConvert.DeserializeObject<UserData>(data);
			return userData;
		}
		return new UserData();
	}
}
