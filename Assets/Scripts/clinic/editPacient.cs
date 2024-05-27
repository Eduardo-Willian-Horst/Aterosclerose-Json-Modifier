using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class editPacient : MonoBehaviour
{
    [SerializeField] private Slider dificultySlider;
    [SerializeField] private GameObject canvasEditPaciente;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private TMP_InputField nameInputText, idadeInputText, pesoInputText, anamneseInputText, nCondsText, nAntecedentesText, nExamFisico, nExamLab;
    [SerializeField] private readCases rc;
    private readCases.casosclinicos_ casoAtual;
    void Update(){
        sliderController();
    }
    void sliderController(){
        int numberActual = (int)dificultySlider.value;
        sliderText.text = numberActual.ToString();
    }
    public void initer(readCases.casosclinicos_ received){
        canvasEditPaciente.SetActive(true);
        casoAtual = received;
        Debug.Log("sou o nome: " + casoAtual.nomepaciente);
        nameInputText.text = casoAtual.nomepaciente;
        idadeInputText.text = casoAtual.idade.ToString();
        pesoInputText.text = casoAtual.peso.ToString();
        anamneseInputText.text = casoAtual.anamnese;
    }
    void updateTexts(){

    }

}
