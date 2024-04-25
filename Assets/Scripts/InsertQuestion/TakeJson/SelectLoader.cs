using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLoader : MonoBehaviour
{
    [SerializeField] private FileSelect fileSelect;
    [SerializeField] private EasyQuestionsReader EasyReader;
    [SerializeField] private HardQuestionsReader HardReader;
    [SerializeField] private MediumQuestionsReader MediumReader;
    [SerializeField] private CanvasController CC;


    public void OnClickContinueButton(){
        LoadQuestions();
    }

    private void LoadQuestionList(){
        switch(fileSelect.getFileName()){
            case "easyQuestions.json":
                EasyReader.LoadEasyQuestions();
                break;
            case "hardQuestions.json":
                HardReader.LoadHardQuestions();
                break;
            case "mediumQuestions.json":
                MediumReader.LoadMediumQuestions();
                break;
        }
    }

    private void LoadQuestions(){
        LoadQuestionList();
        CC.OpenAddQuestion();
    }

}
