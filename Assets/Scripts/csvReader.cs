using System.IO;
using UnityEngine;

public static class csvReader
{
    public static string[] ReadFileData(string name)
    {
        TextAsset textFile = Resources.Load($"csv/{name}") as TextAsset;

        using (StringReader sr = new StringReader(textFile.text))
        {
            string baseData = sr.ReadToEnd();
            return baseData.Split("\r\n");
        }
    }
}
