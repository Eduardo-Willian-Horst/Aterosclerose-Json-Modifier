using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject screenLogin, screenCreateUser, selectAction, openFile, addQuestion,removeQuestion;
    [SerializeField] private ShowQuestion showQuestion;
    [SerializeField] private SelectLoader selectLoader;
    [SerializeField] private Button okButton;
    [SerializeField] private TextMeshProUGUI pathText;
    private string whoYouMake = "addQuestion";

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

    private void DisableAllScreens(){
        screenLogin.SetActive(false);
        screenCreateUser.SetActive(false);
        selectAction.SetActive(false);
        openFile.SetActive(false);
        addQuestion.SetActive(false);
        removeQuestion.SetActive(false);
    }
}
