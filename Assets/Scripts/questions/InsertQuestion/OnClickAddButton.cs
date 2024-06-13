using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnClickAddButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField question, answer1, answer2, answer3, answer4;
    [SerializeField] private Toggle toggleAnswer1, toggleAnswer2, toggleAnswer3, toggleAnswer4;
    [SerializeField] private CheckEmptyInputs CheckInputs;
    [SerializeField] private TextMeshProUGUI errorLog;
    [SerializeField] private EasyQuestionsReader EasyReader;
    [SerializeField] private HardQuestionsReader HardReader;
    [SerializeField] private MediumQuestionsReader MediumReader;
    [SerializeField] private FileSelect fileSelect;
    string correctAnswer;

    public void OnClickAdd(){
        if(CheckInputs.HaveInputsEmpty()){
            errorLog.color = Color.red;
            errorLog.text = "Preencha todos os campos!";
            return;
        }
        if(!CheckInputs.CheckBoxIsMarked()){
            errorLog.color = Color.red;
            errorLog.text = "Marque a resposta correta!";
            return;
        }

        if(!CheckInputs.IsJustOneCheckBoxMarked()){
            errorLog.color = Color.red;
            errorLog.text = "Marque apenas uma resposta!";
            return;
        }

        errorLog.text = "";

        if(toggleAnswer1.isOn) correctAnswer = answer1.text;
        if(toggleAnswer2.isOn) correctAnswer = answer2.text;
        if(toggleAnswer3.isOn) correctAnswer = answer3.text;
        if(toggleAnswer4.isOn) correctAnswer = answer4.text;

        if(fileSelect.getFileName() == "easyQuestions.json") EasyReader.AddNewQuestion(question.text, new List<string>{answer1.text, answer2.text, answer3.text, answer4.text}, correctAnswer);
        if(fileSelect.getFileName() == "hardQuestions.json") HardReader.AddNewQuestion(question.text, new List<string>{answer1.text, answer2.text, answer3.text, answer4.text}, correctAnswer);
        if(fileSelect.getFileName() == "mediumQuestions.json") MediumReader.AddNewQuestion(question.text, new List<string>{answer1.text, answer2.text, answer3.text, answer4.text}, correctAnswer);


        CleanInputs();
        errorLog.color = Color.green;
        errorLog.text = "Adicionado!";
    }



    private void CleanInputs(){
        question.text = "";
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
        toggleAnswer1.isOn = false;
        toggleAnswer2.isOn = false;
        toggleAnswer3.isOn = false;
        toggleAnswer4.isOn = false;
    }





}
