using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestion : MonoBehaviour
{


    [System.Serializable]
    public class question
    {
        public int id;
        public string pergunta;
        public List<string> opcoes;
        public string respostaCorreta;
    }


    [SerializeField] private FileSelect fileSelect;
    [SerializeField] private EasyQuestionsReader EasyReader;
    [SerializeField] private HardQuestionsReader HardReader;
    [SerializeField] private MediumQuestionsReader MediumReader;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private UnityEngine.UI.Button removeQuestionButton;

    public List<question> lista;

    private int questao = 0;
    public int tamanhoListaDeQuestoes;

    public int GetQuestao()
    {
        return questao;
    }
    public void LoadFirstTime()
    {
        LoadQuestions();
        tamanhoListaDeQuestoes = lista.Count;
        description.text = CheckEmptyList();
        
    }


    private void LoadQuestions()
    {
        if (fileSelect.getFileName() == "easyQuestions.json") ConvertEasyQuestions();
        if (fileSelect.getFileName() == "mediumQuestions.json") ConvertMediumQuestions();
        if (fileSelect.getFileName() == "hardQuestions.json") ConvertHardQuestions();

    }

    public void ConvertEasyQuestions()
    {
        lista.Clear();
        var easyQuestionsList = EasyReader.ListaDeQuestoes().easyquestions;

        foreach (var easyQuestion in easyQuestionsList)
        {
            question newQuestion = new question();
            newQuestion.id = easyQuestion.id;
            newQuestion.pergunta = easyQuestion.pergunta;
            newQuestion.opcoes = easyQuestion.opcoes;
            newQuestion.respostaCorreta = easyQuestion.respostaCorreta;

            lista.Add(newQuestion);
        }
    }

    public void ConvertMediumQuestions()
    {
        lista.Clear();
        var mediumQuestionsList = MediumReader.ListaDeQuestoes().mediumquestions;

        foreach (var mediumQuestion in mediumQuestionsList)
        {
            question newQuestion = new question();
            newQuestion.id = mediumQuestion.id;
            newQuestion.pergunta = mediumQuestion.pergunta;
            newQuestion.opcoes = mediumQuestion.opcoes;
            newQuestion.respostaCorreta = mediumQuestion.respostaCorreta;

            lista.Add(newQuestion);
        }
    }

    public void ConvertHardQuestions()
    {
        lista.Clear();
        var hardQuestionsList = HardReader.ListaDeQuestoes().hardquestions;

        foreach (var hardQuestion in hardQuestionsList)
        {
            question newQuestion = new question();
            newQuestion.id = hardQuestion.id;
            newQuestion.pergunta = hardQuestion.pergunta;
            newQuestion.opcoes = hardQuestion.opcoes;
            newQuestion.respostaCorreta = hardQuestion.respostaCorreta;

            lista.Add(newQuestion);
        }
    }

    public void NextQuestion()
    {
        if (questao < tamanhoListaDeQuestoes - 1) questao++;
        description.text = CheckEmptyList();
    }
    public void PreviousQuestion()
    {
        if (questao > 0) questao--;
        description.text = CheckEmptyList();
    }
    public void JustReloadPainel()
    {   questao = 0;
        description.text = CheckEmptyList();
    }

    private string CheckEmptyList()
    {
        tamanhoListaDeQuestoes = lista.Count;
        if (tamanhoListaDeQuestoes == 0)
        {
            
            removeQuestionButton.interactable = false;
            return "A lista de questões se encontra vazia!";
        }
        else {
            removeQuestionButton.interactable = true;
            return $"ID: {lista[questao].id}\nQuestão: {lista[questao].pergunta}\nResposta: {lista[questao].respostaCorreta}";
        }
    }

}
