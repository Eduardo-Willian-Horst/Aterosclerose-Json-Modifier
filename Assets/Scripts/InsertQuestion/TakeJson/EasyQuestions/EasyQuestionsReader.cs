using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class EasyQuestionsReader : MonoBehaviour
{
    [System.Serializable]
    public class question 
    {
        public int id; 
        public string pergunta;
        public List<string> opcoes;
        public string respostaCorreta;
    }

    [System.Serializable]
    public class easyQuestionsList
    {
        public List<question> easyquestions;
    }

    public easyQuestionsList easyList;
    [SerializeField] private FileSelect fileSelect;
    
    public easyQuestionsList ListaDeQuestoes(){
        return easyList;
    } 
    public void LoadEasyQuestions()
    {
        loadQuestions();
    }

    public int EasyQuestionsCount()
    {
        return easyList.easyquestions.Count;
    }

    void loadQuestions()
    {
        string json = File.ReadAllText(fileSelect.getFilePath());
        easyList = JsonUtility.FromJson<easyQuestionsList>(json);
    }

    public void AddNewQuestion(string pergunta, List<string> opcoes, string respostaCorreta)
    {
        if (easyList == null)
            easyList = new easyQuestionsList();

        if (easyList.easyquestions == null)
            easyList.easyquestions = new List<question>();

        question newQuestion = new question();
        newQuestion.id = NextId();
        newQuestion.pergunta = pergunta;
        newQuestion.opcoes = opcoes;
        newQuestion.respostaCorreta = respostaCorreta;

        easyList.easyquestions.Add(newQuestion);
    }

    private int NextId(){
        int newId = 1;
        foreach( question i in easyList.easyquestions){
            if(i.id == newId) newId++;
            else return newId;
        }
        return newId;
    }
    public string SerializeQuestionsToJson()
    {
        
        int id = 1;
        foreach(question item in easyList.easyquestions){
            item.id = id;
            id++;
        }        
        
        return JsonUtility.ToJson(easyList);
    }

        
}

