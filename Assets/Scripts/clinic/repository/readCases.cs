using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class readCases : MonoBehaviour {

    //----------------------------------------//

    [System.Serializable]
    public class questoesClinicas_{
        public int id;
        public int id_paciente;
        public string pergunta;
        public List<string> opcoes;
        public string respostacorreta;
        public questoesClinicas_(){
            id = 0;
            id_paciente = 0;
            pergunta = string.Empty;
            opcoes = new List<string>{ string.Empty, string.Empty, string.Empty, string.Empty};
            respostacorreta = string.Empty;
        }
    }

    [System.Serializable]
    public class questoesClinicasList{
        public List<questoesClinicas_> questoesClinicas;
    }
    public questoesClinicasList questoesList;

    //----------------------------------------//

    [System.Serializable]
    public class casosclinicos_ {
        public int id;
        public int dificuldade;
        public int idade;
        public float peso;
        public float altura;
        public string sexo;
        public string anamnese;
        public List<string> antecedentes;
        public List<string> condicoes;
        public List<string> examesfisicos;
        public List<string> exameslaboratoriais;
        public string nomepaciente;
        public int numerodequestoes;
        public int exprequerida;
        public casosclinicos_(int id_){
            id = id_;
            dificuldade = 1;
            idade = -1;
            peso = -1.0f;
            altura = -1.0f;
            sexo = "";
            anamnese = "";
            antecedentes = new List<string>();
            condicoes = new List<string>();
            examesfisicos = new List<string>();
            exameslaboratoriais = new List<string>();
            nomepaciente = "";
            numerodequestoes = 0;
            exprequerida = 0;
        }
    }

    [System.Serializable]
    public class casosclinicosList {
        public List<casosclinicos_> casosclinicos;
    }
    public casosclinicosList casosList;

    //-----------------------------------------//

    public void startClinic(string path){
        string json = File.ReadAllText(path);
        casosList = JsonUtility.FromJson<casosclinicosList>(json);
    }
    public void startCases(string path){
        string json = File.ReadAllText(path);
        questoesList = JsonUtility.FromJson<questoesClinicasList>(json);
    }
    public casosclinicosList getCasosList(){
        return casosList;
    } 
    public questoesClinicasList getQuestoes(){
        return questoesList;
    }
}
