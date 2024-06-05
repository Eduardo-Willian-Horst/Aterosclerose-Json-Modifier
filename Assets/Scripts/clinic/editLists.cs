using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class editLists : MonoBehaviour
{
    [SerializeField] private GameObject thisPanel, toEdit, toAdd, errorLogText;
    [SerializeField] private TextMeshProUGUI title, textItem;
    [SerializeField] private TMP_InputField inputAdd;
    [SerializeField] private Button rightBtn, leftBtn, deleteBtn, addBtn;
    [SerializeField] private ControllerClinic controllerClinic;
    [SerializeField] private editPacient edtP;
    private List <string> actualList;
    private int index = 0;

    void Start(){
        disablePanel();
    }

    void verifyer(){
        if(actualList.Count>0){
            rightBtn.interactable = true;
            leftBtn.interactable = true;
            deleteBtn.interactable = true;
            index=0;
            attText();
        }else{
            rightBtn.interactable=false;
            leftBtn.interactable=false;
            deleteBtn.interactable = false;
            textItem.text = "Nenhum item encontrado!";
            textItem.color = Color.red;
        }
    }
    void attText(){
        textItem.color = Color.black;
        textItem.text = actualList[index];
    }
    public void deleteItem(){
        actualList.RemoveAt(index);
        verifyer();
    }
    private IEnumerator errorLog(){
        errorLogText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        errorLogText.SetActive(false);
    }
    public void addItem(){
        if(inputAdd.text.Length>0){
            actualList.Add(inputAdd.text);
            inputAdd.text = "";
        }else{
            StartCoroutine(errorLog());
        }
    }
    public void ClickRight(){
        index++;
        if(index==actualList.Count)index=0;
        attText();
    }
    public void ClickLeft(){
        index--;
        if(index<0)index = actualList.Count-1;
        attText();
    }
    void disablePanel(){
        thisPanel.SetActive(false);
    }
    void enablePanel(List <string> received){
        AtribuirPorReferencia(ref received, ref actualList);
        thisPanel.SetActive(true);
        toEdit.SetActive(true);
        toAdd.SetActive(false);
        verifyer();
    }
    void enablePanelToAdd(List <string> received){
        AtribuirPorReferencia(ref received, ref actualList);
        thisPanel.SetActive(true);
        toEdit.SetActive(false);
        toAdd.SetActive(true);
        errorLogText.SetActive(false);

    }
    void AtribuirPorReferencia(ref List<string> origem, ref List<string> destino){
        destino = origem;
    }
    void controlTitle(string name){
        title.text = name;
    }
    public void onClickAlterCond(){
        enablePanel(controllerClinic.getCondicoes());
        controlTitle("Condições");
    }
    public void onClickAddCond(){
        enablePanelToAdd(controllerClinic.getCondicoes());
        controlTitle("Condições");
    }
    public void onClickAlterAnte(){
        enablePanel(controllerClinic.getAntecedentes());
        controlTitle("Antecedentes");
    }
    public void onClickAddAnte(){
        enablePanelToAdd(controllerClinic.getAntecedentes());
        controlTitle("Antecedentes");
    }
    public void onClickAlterFisic(){
        enablePanel(controllerClinic.getExamesFisicos());
        controlTitle("Exames físicos");
    }
    public void onClickAddFisic(){
        enablePanelToAdd(controllerClinic.getExamesFisicos());
        controlTitle("Exames físicos");
    }
    public void onClickAlterLab(){
        enablePanel(controllerClinic.getExamesLaboratoriais());
        controlTitle("Exames laboratoriais");
    }
    public void onClickAddLab(){
        enablePanelToAdd(controllerClinic.getExamesLaboratoriais());
        controlTitle("Exames laboratoriais");
    }
    public void onClickSave(){
        edtP.updateTexts();
        disablePanel();
    }
}
