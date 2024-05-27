using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;
using TMPro;

public class ControllerClinic : MonoBehaviour
{
    [SerializeField] private GameObject editQuestoes;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private readCases readC;
    [SerializeField] private editPacient editP;
    private readCases.casosclinicosList casesList;
    private readCases.questoesClinicasList questoesList;
    private List<readCases.questoesClinicas_> questsForEdit;
    [SerializeField] private Button continueBtn, rightBtn, leftBtn, deletePctBtn, editPctBtn, editQuestBtn, questEditBtn, questRemoveBtn, questNewBtn;
    [SerializeField] private TextMeshProUGUI advice1, advice2, pacient_name, pacient_id, pacient_anamnese, numberofQuestText, questText;
    private bool clinic=false, quest= false;
    private string filePath1, filePath2;


    public void onClickSearchClinic(){
        StartCoroutine(FindFile(1));
    }
    public void onClickSearchQuest(){
        StartCoroutine(FindFile(2));
    }
    public void onClickContinue(){
        if(clinic && quest)canvasController.onClickContinue(filePath1, filePath2);
    }

    void sendError(int which){
        if(which==1){
            advice1.text = "Arquivo Inválido!";
            advice1.color = Color.red;
        }else if(which==2){
            advice2.text = "Arquivo Inválido!";
            advice2.color = Color.red;
        }
    }
    void sendHit(int which){
        if(which==1){
            advice1.text = filePath1+" OK!";
            advice1.color = Color.green;
        }else if(which==2){
            advice2.text = filePath2+" OK!";
            advice2.color = Color.green;
        }
    }

    void verifyContinue(){
        if(clinic && quest)continueBtn.interactable = true;
        else continueBtn.interactable = false;
    }

    IEnumerator FindFile(int whichOne){
        var files = StandaloneFileBrowser.OpenFilePanel("Select File", "", "json", false); 
        yield return new WaitUntil(() => files.Length > 0);
        string selectedFile = files[0];
        if (!string.IsNullOrEmpty(selectedFile)){ 
            if(whichOne==1){
                filePath1 = selectedFile;
                if(Path.GetFileName(filePath1)!="casosClinicos.json"){
                    sendError(1);
                    clinic=false;
                    verifyContinue();
                }else{
                    clinic=true;
                    sendHit(1);
                    verifyContinue();
                }
            }
            else if(whichOne==2){
                filePath2 = selectedFile;
                if(Path.GetFileName(filePath2)!="questoesClinicas.json"){
                    sendError(2);
                    quest=false;
                    verifyContinue();
                }else{
                    quest=true;
                    sendHit(2);
                    verifyContinue();
                }
            }
        }
    }
    void sendReadError(){
        pacient_anamnese.text="";
        pacient_id.text="";
        pacient_name.text="Nenhum paciente carregado!";
        pacient_name.color = Color.red;
        editPctBtn.interactable = false;
        editQuestBtn.interactable = false;
        deletePctBtn.interactable = false;
    }
    private int index = 0;
    public void getterCases(){
        casesList = readC.getCasosList();
        questoesList = readC.getQuestoes();
    }
    public void controlador(){
        if(casesList.casosclinicos.Count==0)sendReadError();
        else{
            pacient_name.text = "Paciente: " + casesList.casosclinicos[index].nomepaciente;
            pacient_name.color = Color.white;
            pacient_id.text = "Id: " + casesList.casosclinicos[index].id.ToString();
            pacient_anamnese.text = "Anamnese: " + casesList.casosclinicos[index].anamnese;
            if(casesList.casosclinicos[index].anamnese.Length>444)pacient_anamnese.fontSize = 28;
            else pacient_anamnese.fontSize=36;
        }
    }
    public void onClickRight(){
        index++;
        if(index==casesList.casosclinicos.Count)index=0;
        controlador();
    }
    public void onClickLeft(){
        index--;
        if(index<0)index=casesList.casosclinicos.Count-1;
        controlador();
    }
    public void onClickNovoPaciente(){

    }
    public void onClickEditarPaciente(){
        canvasController.DisableAllScreens();
        editP.initer(casesList.casosclinicos[index]);

    }
    public void onClickDeletarPaciente(){
        deleteQuestionsMassive(casesList.casosclinicos[index].id);
        casesList.casosclinicos.RemoveAt(index);
        onClickLeft();
        controlador();
    }
    public void questBackToPacients(){
        canvasController.DisableAllScreens();
        canvasController.onClickEditCasosClinicos();
    }
    private void dispareErrorQuest(){
        numberofQuestText.text = "Nenhuma questão encontrada para este paciente!";
        numberofQuestText.color = Color.red;
        questEditBtn.interactable = false;
        questRemoveBtn.interactable = false;
        questText.text="";
    }
    private void noErrors(){
        numberofQuestText.color = Color.white;
        questEditBtn.interactable = true;
        questRemoveBtn.interactable = true;
    }
    public void onClickEditarQuestoes(){
        int id = casesList.casosclinicos[index].id;
        canvasController.DisableAllScreens();
        editQuestoes.SetActive(true);
        if (questsForEdit != null)questsForEdit.Clear();
        else questsForEdit = new List<readCases.questoesClinicas_>();
        for(int i=0; i< questoesList.questoesClinicas.Count; i++){
             if(questoesList.questoesClinicas[i].id_paciente==id)questsForEdit.Add(questoesList.questoesClinicas[i]);
        }
        if(questsForEdit.Count==0){
            dispareErrorQuest();
        }else{
            noErrors();
            initQuestionPanel();
        }
    }
    public readCases.questoesClinicas_ getActualQuest(){
        return questsForEdit[indexQ];
    }
    public int findValidId(){
        return questoesList.questoesClinicas[questoesList.questoesClinicas.Count-1].id+1;
    }
    public int getIdPaciente(){
        return questsForEdit[indexQ].id_paciente;
    }
    int indexQ = 0;
    public void onClickRightQuestoes(){
        indexQ++;
        if(indexQ==questsForEdit.Count)indexQ=0;
        initQuestionPanel();
    }
    public void onClickLeftQuestoes(){
        indexQ--;
        if(indexQ<0)indexQ=questsForEdit.Count-1;
        initQuestionPanel();
    }
    void initQuestionPanel(){
        noErrors();
        numberofQuestText.text = "Número de questões: " + questsForEdit.Count.ToString();
        questText.text = "Id: " + questsForEdit[indexQ].id.ToString() + "\nQuestão: " + questsForEdit[indexQ].pergunta + "\nResposta: " + questsForEdit[indexQ].respostacorreta;
    }
    public void saveEditedQuestion(readCases.questoesClinicas_ edited){
        bool found = false;
        for(int i=0; i<questoesList.questoesClinicas.Count; i++){
            if(edited.id == questoesList.questoesClinicas[i].id){
                questoesList.questoesClinicas[i] = edited;
                found = true;
            }
        }
        if(!found){
            questoesList.questoesClinicas.Add(edited);
        }
    }
    void deleteQuestionsMassive(int identificador){
        for (int i = 0; i < questoesList.questoesClinicas.Count; i++) {
            if (questoesList.questoesClinicas[i].id_paciente == identificador) {
                questoesList.questoesClinicas.RemoveAt(i);
                i--;
            }
        }
    }
    bool verifyNumberOfQuests(){
        if(questsForEdit.Count>0)return true;
        return false;
    }
    public void deleteUniqueQuestion(){
        int id_auxiliar = questsForEdit[indexQ].id;
        questsForEdit.RemoveAt(indexQ);
        for(int i=0; i<questoesList.questoesClinicas.Count;i++){
            if(questoesList.questoesClinicas[i].id==id_auxiliar){
                questoesList.questoesClinicas.RemoveAt(i);
                break;
            }
        }
        if(verifyNumberOfQuests())onClickLeftQuestoes();
        else dispareErrorQuest();
    }
    //public void editQuest(){
    //    ShowQuestion.question q;
    //}
}
