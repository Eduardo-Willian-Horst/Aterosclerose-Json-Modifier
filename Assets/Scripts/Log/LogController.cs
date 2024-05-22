using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System;

public class LogController : MonoBehaviour
{
    
    private string filePath;

    void Start()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        filePath = Path.Combine(documentsPath, "AteroscleroseJsonLog.txt");
    }

    public void NewLog(string acao){
        AddLineToFile(PlayerPrefs.GetString("userInUse") + " " + acao + " [ " + DateTime.Now.ToString() + " ]");
    }

    private void AddLineToFile(string line)
    {
        File.AppendAllText(filePath, line + "\n");
        Debug.Log("Linha adicionada: " + line);
    }

    
}
