using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;
using TMPro;

public class ControllerClinic : MonoBehaviour
{
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private Button continueBtn;
    [SerializeField] private TextMeshProUGUI advice1, advice2;
    private bool clinic=false, quest= false;
    private string filePath1, filePath2;


    public void onClickSearchClinic(){
        Debug.Log("eu executo");
        StartCoroutine(FindFile(1));
    }
    public void onClickSearchQuest(){
        StartCoroutine(FindFile(2));
    }
    public void onClickContinue(){
        if(clinic && quest)canvasController.onClickQuestoesClinicas(filePath1, filePath2);
    }

    void sendError(int which){
        if(which==1){
            advice1.text = "Arquivo Inválido!";
            advice1.color = Color.red;
        }else if(which==2){
            advice2.text = "Arquivo Inválido!";
            advice2.color = Color.red;
        }
    }
    void sendHit(int which){
        if(which==1){
            advice1.text = filePath1+" OK!";
            advice1.color = Color.green;
        }else if(which==2){
            advice2.text = filePath2+" OK!";
            advice2.color = Color.green;
        }
    }

    void verifyContinue(){
        if(clinic && quest)continueBtn.interactable = true;
        else continueBtn.interactable = false;
    }

    IEnumerator FindFile(int whichOne){
        var files = StandaloneFileBrowser.OpenFilePanel("Select File", "", "json", false); 
        yield return new WaitUntil(() => files.Length > 0);
        string selectedFile = files[0];
        if (!string.IsNullOrEmpty(selectedFile)){ 
            if(whichOne==1){
                filePath1 = selectedFile;
                if(Path.GetFileName(filePath1)!="casosClinicos.json"){
                    sendError(1);
                    clinic=false;
                    verifyContinue();
                }else{
                    clinic=true;
                    sendHit(1);
                    verifyContinue();
                }
            }
            else if(whichOne==2){
                filePath2 = selectedFile;
                if(Path.GetFileName(filePath2)!="questoesClinicas.json"){
                    sendError(2);
                    quest=false;
                    verifyContinue();
                }else{
                    quest=true;
                    sendHit(2);
                    verifyContinue();
                }
            }
        }
    }



}
