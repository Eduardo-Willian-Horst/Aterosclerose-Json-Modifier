using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;


public class LoginController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField, passwordInputField;
    [SerializeField] private CanvasController CanvasController;
    [SerializeField] private TextMeshProUGUI ErrorMsg;
    [SerializeField] private LogController Log;

    void Awake(){
        RemoveError();
        PlayerPrefs.SetString("Master", "admin");
    }
    
    private bool ExistInUserBase(){
        if(PlayerPrefs.HasKey(nameInputField.text)) return true;
        return false;
    }

    private bool PasswordIsCorrect(){
        if(PlayerPrefs.GetString(nameInputField.text) == passwordInputField.text) return true;
        return false;
    }

    private bool CheckLogin(){
        if(ExistInUserBase() && PasswordIsCorrect()) return true;
        return false;
    }
    private void SendError(){
        ErrorMsg.text = "ERRO: Usuário ou senha não encontrados";
    }
    private void RemoveError(){
        ErrorMsg.text = "";
    }
    
    public void onClickLogin(){
        if(CheckLogin()){
            RemoveError();
            CanvasController.selectTypeOfArchive();
            PlayerPrefs.SetString("userInUse", nameInputField.text);
            Log.NewLog("logou");
        } else SendError();
    }
}
