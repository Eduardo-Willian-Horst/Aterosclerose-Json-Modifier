using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class editQuestion : MonoBehaviour
{
    [SerializeField] private TMP_InputField question, answer1, answer2, answer3, answer4;
    [SerializeField] private Toggle toggleAnswer1, toggleAnswer2, toggleAnswer3, toggleAnswer4;
    [SerializeField] private CheckEmptyInputs CheckInputs;
    [SerializeField] private ShowQuestion showQuestions;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private TextMeshProUGUI errorLog;
    private ShowQuestion.question questForEdit;

    public void edit(ShowQuestion.question q){
        questForEdit = q;
        question.text = q.pergunta;
        answer1.text = q.opcoes[0];
        answer2.text = q.opcoes[1];
        answer3.text = q.opcoes[2];
        answer4.text = q.opcoes[3];
    }
    public void onClickSave(){
        questForEdit.pergunta = question.text;
        questForEdit.opcoes[0] = answer1.text;
        questForEdit.opcoes[1] = answer2.text;
        questForEdit.opcoes[2] = answer3.text;
        questForEdit.opcoes[3] = answer4.text;
        if(chooseCorrectAnswer()){
            errorLog.text = "";
            canvasController.OpenRemoveQuestion();
            showQuestions.updateQuestion(questForEdit);
            return;
        }
        errorLog.color = Color.red;
        errorLog.text = "Marque apenas uma resposta!";
    }
    bool chooseCorrectAnswer(){
        int checkSum =0;
        if(toggleAnswer1.isOn){
            checkSum++;
            questForEdit.respostaCorreta = questForEdit.opcoes[0];
        }
        if(toggleAnswer2.isOn){
            checkSum++;
            questForEdit.respostaCorreta = questForEdit.opcoes[1];
        }
        if(toggleAnswer3.isOn){
            checkSum++;
            questForEdit.respostaCorreta = questForEdit.opcoes[2];
        }
        if(toggleAnswer4.isOn){
            checkSum++;
            questForEdit.respostaCorreta = questForEdit.opcoes[3];
        }
        if(checkSum==1)return true;
        return false;
    }

}
