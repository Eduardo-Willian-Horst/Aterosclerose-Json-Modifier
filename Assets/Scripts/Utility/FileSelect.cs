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
    private string filePathEz, filePathMe, filePathHa;

    public string getFilePath(string difficulty){
        switch(difficulty){
            case "easy":
                return filePathEz;
                break;
            case "medium":
                return filePathMe;
                break;
            case "hard":
                return filePathHa;
        }
        return filePathEz;
    }

    public string getFileName(){
        return Path.GetFileName(filePathEz);
    }

    public void onClickFindFile(){
        StartCoroutine(FindFile());

    }


    IEnumerator FindFile() {
    
    var files = StandaloneFileBrowser.OpenFilePanel("Select File", "", "json", false);

    
    yield return new WaitUntil(() => files.Length > 0);

    
    string selectedFile = files[0];

    if (!string.IsNullOrEmpty(selectedFile)) {
        
        filePathEz = selectedFile;
            
        CheckFileName();
    }
}
// CORRIGIR TODOS OS CAMINHOS FILEPATHEZ, SÓ FOI COLOCADO PARA RETIRAR ERROS DE COMPILAÇÃO


    private void CheckFileName(){
        if(Path.GetFileName(filePathEz) != "easyQuestions.json" &&
        Path.GetFileName(filePathHa) != "hardQuestions.json" &&
        Path.GetFileName(filePathMe) != "mediumQuestions.json") ShowFileNameWithError();
        else ShowFileNameWithoutError();
    }

    private void ShowFileNameWithError(){
        fileNameTMP.color = Color.red;
        fileNameTMP.text = "O nome do arquivo " + Path.GetFileName(filePathEz) + " não é válido!";
        DisactiveContinueButton();
    }

    private void ShowFileNameWithoutError(){
        fileNameTMP.color = Color.green;
        fileNameTMP.text = Path.GetFileName(filePathEz);
        ActiveContinueButton();
    }

    private void ActiveContinueButton(){
        continueButton.interactable = true;
    }

    private void DisactiveContinueButton(){
        continueButton.interactable = false;
    }
}
