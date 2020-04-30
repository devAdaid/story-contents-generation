using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class DefaultDatabase
{
    [MenuItem("Data/Export Data")]
    public static void ExportData()
    {
        string dataDirectoryPath = string.Format("Assets/Resources/storydb.json");
        if (!File.Exists(dataDirectoryPath))
        {
            File.Create(dataDirectoryPath);
        }
    }
}