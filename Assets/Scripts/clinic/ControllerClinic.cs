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
    [SerializeField] private readCases readC;
    private readCases.casosclinicosList casesList;
    private readCases.questoesClinicasList questoesList;
    [SerializeField] private Button continueBtn, rightBtn, leftBtn, deletePctBtn, editPctBtn, editQuestBtn;
    [SerializeField] private TextMeshProUGUI advice1, advice2, pacient_name, pacient_id, pacient_anamnese;
    private bool clinic=false, quest= false;
    private string filePath1, filePath2;


    public void onClickSearchClinic(){
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
    void sendReadError(){
        pacient_anamnese.text="";
        pacient_id.text="";
        pacient_name.text="Nenhum paciente carregado!";
        pacient_name.color = Color.red;
        editPctBtn.interactable = false;
        editQuestBtn.interactable = false;
        deletePctBtn.interactable = false;
    }
    private int index = 0;
    public void getterCases(){
        casesList = readC.getCasosList();
        questoesList = readC.getQuestoes();
    }
    public void controlador(){
        if(casesList.casosclinicos.Count==0)sendReadError();
        else{
            pacient_name.text = "Paciente: " + casesList.casosclinicos[index].nomepaciente;
            pacient_name.color = Color.white;
            pacient_id.text = "Id: " + casesList.casosclinicos[index].id.ToString();
            pacient_anamnese.text = "Anamnese: " + casesList.casosclinicos[index].anamnese;
            if(casesList.casosclinicos[index].anamnese.Length>444)pacient_anamnese.fontSize = 28;
            else pacient_anamnese.fontSize=36;
        }
    }
    public void onClickRight(){
        index++;
        if(index==casesList.casosclinicos.Count)index=0;
        controlador();
    }
    public void onClickLeft(){
        index--;
        if(index<0)index=casesList.casosclinicos.Count-1;
        controlador();
    }
    public void onClickNovoPaciente(){

    }
    public void onClickEditarPaciente(){

    }
    public void onClickDeletarPaciente(){
        deleteQuestions(casesList.casosclinicos[index].id);
        casesList.casosclinicos.RemoveAt(index);
        onClickLeft();
        controlador();
    }
    public void onClickEditarQuestoes(){

    }
    void deleteQuestions(int identificador){
        for (int i = 0; i < questoesList.questoesClinicas.Count; i++) {
            if (questoesList.questoesClinicas[i].id_paciente == identificador) {
                questoesList.questoesClinicas.RemoveAt(i);
                i--;
            }
        }
}


}
