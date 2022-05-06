using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

[System.Serializable]
public class Model
{
    public int ID;
    public string CreatedAt;
    public string UpdatedAt;
    public string DeletedAt;
    public string Name;
    public string Email;
    public string Password;
}

public class Result
{
    public Model[] result;
}


public class Web_text : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventManager.OnGetWeb.AddListener(PrintText);
    }

    void PrintText(string str)
    {
        
        Result myObject = JsonUtility.FromJson<Result>("{\"result\":" + str + "}");
        //foreach (Model i in myObject.result)
        //{
        //    Type t = typeof(Model);
        //    PropertyInfo[] pi = t.GetProperties();

        //    foreach(PropertyInfo p in pi)
        //    {
        //        Debug.Log($"Prop: {p}");
        //    }

        //}

        //Type myType = myObject.GetType();
        //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

        //foreach (PropertyInfo prop in props)
        //{
        //    object propValue = prop.GetValue(myObject, null);

        //    Debug.Log($"Prop: {propValue}");
        //}

        string sm = "";
        foreach (var k in myObject.result)
        {
            sm += $"ID: {k.ID}, Name: {k.Name}, Email: {k.Email}, Registry Date: {k.CreatedAt} \n";
        }
        Debug.Log("Last Name: " + myObject.result[myObject.result.Length - 1].Name);
        GetComponent<Text>().text = sm;
    }
}
