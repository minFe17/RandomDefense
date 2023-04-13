using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCsv : MonoBehaviour
{
    void Start()
    {
        var data = csvReader.ReadFileData("BulletData");
        foreach(var text in data)
        {
            Debug.Log($"텍스트는 : {text}");
        }
    }

    
}
