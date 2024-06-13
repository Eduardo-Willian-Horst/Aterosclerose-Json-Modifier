using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckEmptyInputs : MonoBehaviour
{
    [SerializeField] private TMP_InputField question, answer1, answer2, answer3, answer4;
    [SerializeField] private Toggle toggleAnswer1, toggleAnswer2, toggleAnswer3, toggleAnswer4;

    public bool HaveInputsEmpty(){
        if(question.text == "" || answer1.text == "" || answer2.text == "" || answer3.text == "" || answer4.text == "") return true;
        return false;
    }

    public bool CheckBoxIsMarked(){
        if(!toggleAnswer1.isOn && toggleAnswer2.isOn == false && toggleAnswer3.isOn == false && toggleAnswer4.isOn == false) return false;
        return true;
    }

    public bool IsJustOneCheckBoxMarked(){
        int checkedCount = 0;
        if (toggleAnswer1.isOn) checkedCount++;
        if (toggleAnswer2.isOn) checkedCount++;
        if (toggleAnswer3.isOn) checkedCount++;
        if (toggleAnswer4.isOn) checkedCount++;

        return checkedCount == 1;
    }



}
