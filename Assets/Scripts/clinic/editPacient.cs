using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class editPacient : MonoBehaviour
{
    [SerializeField] private Slider dificultySlider;
    [SerializeField] private GameObject canvasEditPaciente;
    [SerializeField] private ControllerClinic controllerClinic;
    [SerializeField] private TextMeshProUGUI sliderText, nCondsText, nAntecedentesText, nExamFisico, nExamLab;
    [SerializeField] private TMP_InputField nameInputText, idadeInputText, pesoInputText, alturaInputText, anamneseInputText;
    [SerializeField] private Button alterarCondBtn, addCondBtn, alterarAnteBtn, addAnteBtn, alterarFisicBtn, addFisicBtn, alterarLabBtn, addLabBtn;
    [SerializeField] private readCases rc;
    [SerializeField] private Toggle femTogg, mascTogg;
    private readCases.casosclinicos_ casoAtual;
    void Update(){
        if(canvasEditPaciente.activeInHierarchy)
            sliderController();
    }
    void sliderController(){
        int numberActual = (int)dificultySlider.value;
        casoAtual.dificuldade = numberActual;
        sliderText.text = numberActual.ToString();
    }
    public void initer(readCases.casosclinicos_ received){
        canvasEditPaciente.SetActive(true);
        casoAtual = received;
        trataListasBefore();
        nameInputText.text = casoAtual.nomepaciente;
        idadeInputText.text = casoAtual.idade.ToString();
        pesoInputText.text = casoAtual.peso.ToString();
        alturaInputText.text = casoAtual.altura.ToString();
        anamneseInputText.text = casoAtual.anamnese;
        dificultySlider.value = casoAtual.dificuldade;
        if(casoAtual.sexo=="F")femTogg.isOn = true;
        else mascTogg.isOn = true;
        updateTexts();
    }
    void buttonsInteractables(){
        if(casoAtual.condicoes.Count==0){
            alterarCondBtn.interactable = false;
        }else{
            alterarCondBtn.interactable = true;
        }
        if(casoAtual.antecedentes.Count==0){
            alterarAnteBtn.interactable = false;
        }else{
            alterarAnteBtn.interactable = true;
        }
        if(casoAtual.examesfisicos.Count==0){
            alterarFisicBtn.interactable = false;
        }else{
            alterarFisicBtn.interactable = true;
        }
        if(casoAtual.exameslaboratoriais.Count==0){
            alterarLabBtn.interactable = false;
        }else{
            alterarLabBtn.interactable = true;
        }
    }
    public void updateTexts(){
        nCondsText.text = "nº de condições: " + casoAtual.condicoes.Count;
        nAntecedentesText.text = "nº de antecedentes: " + casoAtual.antecedentes.Count;
        nExamFisico.text = "nº de exames fisicos: " + casoAtual.examesfisicos.Count;
        nExamLab.text = "nº de exames laboratoriais: " + casoAtual.exameslaboratoriais.Count;
        buttonsInteractables();
    }
    void trataListasBefore(){
        if(casoAtual.condicoes.Count==1 && casoAtual.condicoes[0]=="Indisponível"){
            casoAtual.condicoes.RemoveAt(0);
        }
        if(casoAtual.antecedentes.Count==1 && casoAtual.antecedentes[0]=="Indisponível"){
            casoAtual.antecedentes.RemoveAt(0);
        }
        if(casoAtual.examesfisicos.Count==1 && casoAtual.examesfisicos[0]=="Indisponível"){
            casoAtual.examesfisicos.RemoveAt(0);
        }
        if(casoAtual.exameslaboratoriais.Count==1 && casoAtual.exameslaboratoriais[0]=="Indisponível"){
            casoAtual.exameslaboratoriais.RemoveAt(0);
        }
    }
    void trataListasAfter(){
        if(casoAtual.condicoes.Count==0){
            casoAtual.condicoes.Add("Indisponível");
        }
        if(casoAtual.antecedentes.Count==0){
            casoAtual.antecedentes.Add("Indisponível");
        }
        if(casoAtual.examesfisicos.Count==0){
            casoAtual.examesfisicos.Add("Indisponível");
        }
        if(casoAtual.exameslaboratoriais.Count==0){
            casoAtual.exameslaboratoriais.Add("Indisponível");
        }
    }
    public void onClickSave(){
        casoAtual.nomepaciente = nameInputText.text;
        casoAtual.idade = int.Parse(idadeInputText.text);
        casoAtual.peso = double.Parse(pesoInputText.text);
        casoAtual.altura = (double)Math.Round(double.Parse(alturaInputText.text),2);
        if(mascTogg.isOn)casoAtual.sexo="M";
        else casoAtual.sexo="F";
        casoAtual.anamnese = anamneseInputText.text;
        trataListasAfter();
        controllerClinic.receiveAttCase(casoAtual);
    }
}
