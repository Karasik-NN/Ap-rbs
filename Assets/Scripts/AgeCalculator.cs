using UnityEngine;
using TMPro;
using System;

public class AgeCalculator : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField yearInputField;
    public TextMeshProUGUI resultText;

    public void DisplayInfo()
    {
        string charName = nameInputField.text;
        
        if (int.TryParse(yearInputField.text, out int birthYear))
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            resultText.text = "Supervaronis " + charName + " ir " + age + " gada";
        }
        else
        {
            resultText.text = "Ievadiet derīgu gadu!";
        }
    }
}