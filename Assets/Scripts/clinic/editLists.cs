using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class editLists : MonoBehaviour
{
    [SerializeField] private GameObject thisPanel;
    [SerializeField] private TextMeshProUGUI title;

    void disablePanel(){
        thisPanel.SetActive(false);
    }
    void enablePanel(){
        thisPanel.SetActive(true);
    }
    void controlTitle(string name){
        title.text = name;
    }
    public void onClickAlterCond(){
        enablePanel();
        controlTitle("Condições");
    }
    public void onClickAddCond(){
        enablePanel();
        controlTitle("Condições");
    }
    public void onClickAlterAnte(){
        enablePanel();
        controlTitle("Antecedentes");
    }
    public void onClickAddAnte(){
        enablePanel();
        controlTitle("Antecedentes");
    }
    public void onClickAlterFisic(){
        enablePanel();
        controlTitle("Exames físicos");
    }
    public void onClickAddFisic(){
        enablePanel();
        controlTitle("Exames físicos");
    }
    public void onClickAlterLab(){
        enablePanel();
        controlTitle("Exames laboratoriais");
    }
    public void onClickAddLab(){
        enablePanel();
        controlTitle("Exames laboratoriais");
    }
    public void onClickSave(){
        disablePanel();
    }
}
