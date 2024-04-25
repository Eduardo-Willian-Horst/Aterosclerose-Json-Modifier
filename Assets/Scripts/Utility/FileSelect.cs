using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using SFB;

public class FileSelect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fileNameTMP;
    [SerializeField] Button continueButton;
    private string filePath;

    

    public string getFilePath(){
        return filePath;
    }

    public string getFileName(){
        return Path.GetFileName(filePath);
    }

    public void onClickFindFile(){
        StartCoroutine(FindFile());

    }


    IEnumerator FindFile() {
    
    var files = StandaloneFileBrowser.OpenFilePanel("Select File", "", "json", false);

    
    yield return new WaitUntil(() => files.Length > 0);

    
    string selectedFile = files[0];

    if (!string.IsNullOrEmpty(selectedFile)) {
        
        filePath = selectedFile;
            
        CheckFileName();
    }
}



    private void CheckFileName(){
        if(Path.GetFileName(filePath) != "easyQuestions.json" &&
        Path.GetFileName(filePath) != "hardQuestions.json" &&
        Path.GetFileName(filePath) != "mediumQuestions.json") ShowFileNameWithError();
        else ShowFileNameWithoutError();
    }

    private void ShowFileNameWithError(){
        fileNameTMP.color = Color.red;
        fileNameTMP.text = "O nome do arquivo " + Path.GetFileName(filePath) + " não é válido!";
        DisactiveContinueButton();
    }

    private void ShowFileNameWithoutError(){
        fileNameTMP.color = Color.green;
        fileNameTMP.text = Path.GetFileName(filePath);
        ActiveContinueButton();
    }

    private void ActiveContinueButton(){
        continueButton.interactable = true;
    }

    private void DisactiveContinueButton(){
        continueButton.interactable = false;
    }
}
