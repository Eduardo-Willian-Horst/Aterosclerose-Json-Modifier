using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ExportJson : MonoBehaviour
{

    [SerializeField] private FileSelect fileSelect;
    [SerializeField] private EasyQuestionsReader EasyReader;
    [SerializeField] private HardQuestionsReader HardReader;
    [SerializeField] private MediumQuestionsReader MediumReader;
    [SerializeField] private ShowQuestion showQuestion;
    [SerializeField] private DialogBoxController dialogBox;

    public void Export(){
        if(fileSelect.getFileName() == "easyQuestions.json") File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "easyQuestions.json"), EasyReader.SerializeQuestionsToJson());
        if(fileSelect.getFileName() == "mediumQuestions.json") File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "mediumQuestions.json"), MediumReader.SerializeQuestionsToJson());
        if(fileSelect.getFileName() == "hardQuestions.json") File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "hardQuestions.json"), HardReader.SerializeQuestionsToJson());
        dialogBox.ShowMsg($"Arquivo {fileSelect.getFileName()} salvo na área de trabalho!");
    }

    public void ExportAfterDelete(){
        
        if(fileSelect.getFileName() == "easyQuestions.json") {
            EasyReader.easyList.easyquestions.Clear();
            foreach(ShowQuestion.question questao in showQuestion.lista){

                EasyQuestionsReader.question newQuestion = new EasyQuestionsReader.question();
                newQuestion.id = questao.id;
                newQuestion.pergunta = questao.pergunta;
                newQuestion.respostaCorreta = questao.respostaCorreta;
                newQuestion.opcoes = questao.opcoes;
                EasyReader.easyList.easyquestions.Add(newQuestion);
            }
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "easyQuestions.json"), EasyReader.SerializeQuestionsToJson());
            }
        if(fileSelect.getFileName() == "mediumQuestions.json") {
            MediumReader.mediumList.mediumquestions.Clear();
            foreach(ShowQuestion.question questao in showQuestion.lista){

                MediumQuestionsReader.question newQuestion = new MediumQuestionsReader.question();
                newQuestion.id = questao.id;
                newQuestion.pergunta = questao.pergunta;
                newQuestion.respostaCorreta = questao.respostaCorreta;
                newQuestion.opcoes = questao.opcoes;
                MediumReader.mediumList.mediumquestions.Add(newQuestion);
            }
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "mediumQuestions.json"), MediumReader.SerializeQuestionsToJson());
        }
        if(fileSelect.getFileName() == "hardQuestions.json") {
            HardReader.hardList.hardquestions.Clear();
            foreach(ShowQuestion.question questao in showQuestion.lista){

                HardQuestionsReader.question newQuestion = new HardQuestionsReader.question();
                newQuestion.id = questao.id;
                newQuestion.pergunta = questao.pergunta;
                newQuestion.respostaCorreta = questao.respostaCorreta;
                newQuestion.opcoes = questao.opcoes;
                HardReader.hardList.hardquestions.Add(newQuestion);
            }
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "hardQuestions.json"), HardReader.SerializeQuestionsToJson());
        }

        dialogBox.ShowMsg("Arquivo salvo na área de trabalho!");
    }



    public string SerializeQuestionsToJson(List<ShowQuestion.question> lista)
    {
        
        int id = 1;
        foreach(ShowQuestion.question item in lista){
            item.id = id;
            id++;
        }        
        
        return JsonUtility.ToJson(lista);
    }
}
