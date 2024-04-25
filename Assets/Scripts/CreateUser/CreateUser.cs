using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class CreateUser : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField, passwordInputField, repeatPasswordInputField;
    [SerializeField] private TextMeshProUGUI ErrorMsg;

    void Awake(){
        RemoveError();
    }

    public void onClickCreateUser(){
        ErrorMsg.color = Color.red;
        if(InputFieldsIsNull()) {
            ErrorMsg.text = "ERRO: Preencha todos os campos!";    
            return;
        }
        if(PasswordRepeatIsCorrect()){
            ErrorMsg.text = "ERRO: As senhas devem ser iguais!";    
            return;
        }
        if(UserExist()){
            ErrorMsg.text = "ERRO: Nome de usuário já existente!";    
            return;
        }

        StartCoroutine(CreateUserSequence());
    }

    private void RemoveError(){
        ErrorMsg.text = "";
    }

    private void InsertUser(){
        PlayerPrefs.SetString(nameInputField.text, passwordInputField.text);
    }

    private bool UserExist(){
        if(PlayerPrefs.HasKey(nameInputField.text)) return true;
        return false;
    }

    private bool InputFieldsIsNull(){
        if(nameInputField.text == "" || passwordInputField.text == "" ||  repeatPasswordInputField.text == "") return true;
        return false;
    }
    private bool PasswordRepeatIsCorrect(){
        if(passwordInputField.text == repeatPasswordInputField.text) return false;
        return true;
    }

    IEnumerator CreateUserSequence(){
        ErrorMsg.color = Color.blue;
        ErrorMsg.text = "Criando Usuario...";
        InsertUser();
        ErrorMsg.color = Color.green;
        ErrorMsg.text = "Usuário Criado!";
        yield return null;
    }

}
