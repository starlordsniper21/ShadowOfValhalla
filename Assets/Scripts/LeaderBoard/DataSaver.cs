using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;


[Serializable]
public class dataToSave
{
    public string userName;
    public List<string> names; // List of player names
    public List<string> time;  // List of player times in "00:00" format

    public dataToSave()
    {
        names = new List<string>();
        time = new List<string>();
    }
}



public class DataSaver : MonoBehaviour
{

    public dataToSave dts;
    public string userId;
    DatabaseReference dbref;

    private void Awake()
    {
        dbref = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveDataFn()
    {
        string json = JsonUtility.ToJson(dts);
        dbref.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

    public void LoadDataFn()
    {
        StartCoroutine(LoadDataEnum());
    }

    IEnumerator LoadDataEnum()
    {
        var serverData = dbref.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate:  () => serverData.IsCompleted);

        print("process completed");

        DataSnapshot snapshot = serverData.Result;
        string jsonData = snapshot.GetRawJsonValue();

        if(jsonData != null)
        {
            print("server data not found");
            dts = JsonUtility.FromJson<dataToSave>(jsonData);
        }
        else
        {
            print("no data found");
        }

    }


}
