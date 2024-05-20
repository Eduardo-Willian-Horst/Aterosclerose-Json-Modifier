using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject screenLogin, screenCreateUser, selectAction, openFile, addQuestion,removeQuestion, editQuestion, selectType, clinicCases, selectClinicCase;
    [SerializeField] private ShowQuestion showQuestion;
    [SerializeField] private editQuestion edit_Question;
    [SerializeField] private SelectLoader selectLoader;
    [SerializeField] private readCases readC;
    [SerializeField] private ControllerClinic controllerClinic;
    [SerializeField] private Button okButton;
    [SerializeField] private TextMeshProUGUI pathText;
    private string whoYouMake = "addQuestion";
    private ShowQuestion.question questForEdit;
    
    void Start(){
        OpenScreenLogin();
    }

    public void OpenScreenLogin(){
        DisableAllScreens();
        screenLogin.SetActive(true);
    }

    public void OpenScreenCreateUser(){
        DisableAllScreens();
        screenCreateUser.SetActive(true);
    }

    public void OpenSelectAction(){
        DisableAllScreens();
        selectAction.SetActive(true);
    }
    public void selectTypeOfArchive(){
        DisableAllScreens();
        selectType.SetActive(true);
    }

    public void OpenOpenFile(){
        DisableAllScreens();
        openFile.SetActive(true);
    }
    public void OnClickAddActionBtn(){
        OpenOpenFile();
        whoYouMake = "addQuestion";
    }
    public void OnClickRemoveActionBtn(){
        OpenOpenFile();
        whoYouMake = "RemoveQuestion";
    }
    public void OnClickContinueAfterClickInContinue(){
        okButton.interactable = false;
        pathText.text = "";
        if(whoYouMake == "addQuestion") {
            selectLoader.OnClickContinueButton();
            OpenAddQuestion();
        }
        if(whoYouMake == "RemoveQuestion") {
            selectLoader.OnClickContinueButton();
            OpenRemoveQuestion();
            showQuestion.LoadFirstTime();
        }
    }
    public void OpenRemoveQuestion(){
        DisableAllScreens();
        removeQuestion.SetActive(true);
    }
    public void OpenAddQuestion(){
        DisableAllScreens();
        addQuestion.SetActive(true);
    }
    public void onClickEdit(){
        questForEdit = showQuestion.getActualQuestion();
        //Debug.Log(questForEdit.id);
        DisableAllScreens();
        editQuestion.SetActive(true);
        edit_Question.edit(questForEdit);
    }
    public void onClickCasosClinicos(){
        DisableAllScreens();
        clinicCases.SetActive(true);
    }
    public void onClickEditCasosClinicos(){
        DisableAllScreens();
        selectClinicCase.SetActive(true);

    }
    public void onClickQuestoesClinicas(string path1, string path2){
        DisableAllScreens();
        selectClinicCase.SetActive(true);
        readC.startClinic(path1);
        readC.startCases(path2);
        controllerClinic.getterCases();
        controllerClinic.controlador();
    }

    private void DisableAllScreens(){
        editQuestion.SetActive(false);
        screenLogin.SetActive(false);
        screenCreateUser.SetActive(false);
        selectAction.SetActive(false);
        openFile.SetActive(false);
        addQuestion.SetActive(false);
        selectType.SetActive(false);
        removeQuestion.SetActive(false);
        clinicCases.SetActive(false);
        selectClinicCase.SetActive(false);
    }
}
