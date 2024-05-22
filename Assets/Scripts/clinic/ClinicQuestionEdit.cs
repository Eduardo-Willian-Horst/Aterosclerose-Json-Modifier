using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ClinicQuestionEdit : MonoBehaviour
{
    [SerializeField] private GameObject CanvasClinicEdit;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private ControllerClinic clinicController;
    [SerializeField] private readCases readC;
    private readCases.questoesClinicas_ questionForEdit;
    [SerializeField] private TMP_InputField question, answer1, answer2, answer3, answer4;
    [SerializeField] private Toggle toggleAnswer1, toggleAnswer2, toggleAnswer3, toggleAnswer4;
    [SerializeField] private TextMeshProUGUI errorLog;
    readCases.questoesClinicas_ q;

    public void onClickNew(){
        questionForEdit = new readCases.questoesClinicas_();
        questionForEdit.id = clinicController.findValidId();
        questionForEdit.id_paciente = clinicController.getIdPaciente();
        question.text = questionForEdit.pergunta;
        answer1.text = questionForEdit.opcoes[0];
        answer2.text = questionForEdit.opcoes[1];
        answer3.text = questionForEdit.opcoes[2];
        answer4.text = questionForEdit.opcoes[3];
        canvasController.DisableAllScreens();
        CanvasClinicEdit.SetActive(true);
    }
    public void onClickEdit(){
        questionForEdit = clinicController.getActualQuest();
        canvasController.DisableAllScreens();
        CanvasClinicEdit.SetActive(true);
        question.text = questionForEdit.pergunta;
        answer1.text = questionForEdit.opcoes[0];
        answer2.text = questionForEdit.opcoes[1];
        answer3.text = questionForEdit.opcoes[2];
        answer4.text = questionForEdit.opcoes[3];
    }
    public void onClickSave(){
        if(verifyer()){
            errorLog.text = "";
            questionForEdit.pergunta = question.text;
            questionForEdit.opcoes[0] = answer1.text;
            questionForEdit.opcoes[1] = answer2.text;
            questionForEdit.opcoes[2] = answer3.text;
            questionForEdit.opcoes[3] = answer4.text;
            clinicController.saveEditedQuestion(questionForEdit);
            canvasController.DisableAllScreens();
            canvasController.onClickEditCasosClinicos();
        }else{
            errorLog.text = "Marque apenas 1 opção!";
            errorLog.color = Color.red;
        }
    }

    bool verifyer(){
        int checkSum =0;
        if(toggleAnswer1.isOn){
            checkSum++;
            questionForEdit.respostacorreta = answer1.text;
        }
        if(toggleAnswer2.isOn){
            checkSum++;
            questionForEdit.respostacorreta = answer2.text;
        }
        if(toggleAnswer3.isOn){
            checkSum++;
            questionForEdit.respostacorreta = answer3.text;
        }
        if(toggleAnswer4.isOn){
            checkSum++;
            questionForEdit.respostacorreta = answer4.text;
        }
        if(checkSum==1)return true;
        return false;
    }

}
