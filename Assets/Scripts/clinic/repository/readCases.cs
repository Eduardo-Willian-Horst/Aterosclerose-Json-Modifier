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
