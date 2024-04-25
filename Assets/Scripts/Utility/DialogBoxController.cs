using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBoxController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject dialogBox;

    void Awake(){
        dialogBox.gameObject.SetActive(false);
    }

    public void ShowMsg( string mensagem ){
        dialogBox.SetActive(true);
        text.text = mensagem;
    }

    public void DestroyDialogBox(){
        dialogBox.SetActive(false);    
    }



}
