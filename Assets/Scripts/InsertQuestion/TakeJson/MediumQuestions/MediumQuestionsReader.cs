using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MediumQuestionsReader : MonoBehaviour
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
    public class mediumQuestionsList
    {
        public List<question> mediumquestions;
    }

    public mediumQuestionsList mediumList;
    [SerializeField] private FileSelect fileSelect;
    
    public mediumQuestionsList ListaDeQuestoes(){
        return mediumList;
    } 
    public void LoadMediumQuestions()
    {
        loadQuestions();
    }

    public int MediumQuestionsCount()
    {
        return mediumList.mediumquestions.Count;
    }

    void loadQuestions()
    {
        string json = File.ReadAllText(fileSelect.getFilePath());
        mediumList = JsonUtility.FromJson<mediumQuestionsList>(json);
    }

    public void AddNewQuestion(string pergunta, List<string> opcoes, string respostaCorreta)
    {
        if (mediumList == null)
            mediumList = new mediumQuestionsList();

        if (mediumList.mediumquestions == null)
            mediumList.mediumquestions = new List<question>();

        question newQuestion = new question();
        newQuestion.id = NextId();
        newQuestion.pergunta = pergunta;
        newQuestion.opcoes = opcoes;
        newQuestion.respostaCorreta = respostaCorreta;

        mediumList.mediumquestions.Add(newQuestion);
    }

    private int NextId(){
        int newId = 1;
        foreach( question i in mediumList.mediumquestions){
            if(i.id == newId) newId++;
            else return newId;
        }
        return newId;
    }
    public string SerializeQuestionsToJson()
    {
        
        int id = 1;
        foreach(question item in mediumList.mediumquestions){
            item.id = id;
            id++;
        }        
        
        return JsonUtility.ToJson(mediumList);
    }

        
}
