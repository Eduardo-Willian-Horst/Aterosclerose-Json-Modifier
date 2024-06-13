using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class HardQuestionsReader : MonoBehaviour
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
    public class hardQuestionsList
    {
        public List<question> hardquestions;
    }

    public hardQuestionsList hardList;
    [SerializeField] private FileSelect fileSelect;
    
    public hardQuestionsList ListaDeQuestoes(){
        return hardList;
    } 

    public int HardQuestionsCount()
    {
        return hardList.hardquestions.Count;
    }

    public void loadQuestions(string path)
    {
        string json = File.ReadAllText(path);
        hardList = JsonUtility.FromJson<hardQuestionsList>(json);
    }

    public void AddNewQuestion(string pergunta, List<string> opcoes, string respostaCorreta)
    {
        if (hardList == null)
            hardList = new hardQuestionsList();

        if (hardList.hardquestions == null)
            hardList.hardquestions = new List<question>();

        question newQuestion = new question();
        newQuestion.id = NextId();
        newQuestion.pergunta = pergunta;
        newQuestion.opcoes = opcoes;
        newQuestion.respostaCorreta = respostaCorreta;

        hardList.hardquestions.Add(newQuestion);
    }

    private int NextId(){
        int newId = 1;
        foreach( question i in hardList.hardquestions){
            if(i.id == newId) newId++;
            else return newId;
        }
        return newId;
    }
    public string SerializeQuestionsToJson()
    {
        
        int id = 1;
        foreach(question item in hardList.hardquestions){
            item.id = id;
            id++;
        }        
        
        return JsonUtility.ToJson(hardList);
    }

        
}

