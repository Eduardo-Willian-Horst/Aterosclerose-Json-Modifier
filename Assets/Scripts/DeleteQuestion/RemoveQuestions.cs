using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveQuestions : MonoBehaviour
{
    [SerializeField] private FileSelect fileSelect;
    [SerializeField] private ShowQuestion showQuestion;
    public void OnClickDeleteQuestion(){
            showQuestion.lista.Remove(showQuestion.lista[showQuestion.GetQuestao()]);
            showQuestion.JustReloadPainel();
            showQuestion.tamanhoListaDeQuestoes--;
    }
}
