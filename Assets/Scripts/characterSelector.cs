using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public TextMeshProUGUI descriptionText;
    public string[] descriptions;

    public void ChangeCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
        descriptionText.text = descriptions[index];
    }
    public void ChangeWidth(float value)
    {
        foreach (GameObject charObj in characters)
        {
            Vector3 scale = charObj.transform.localScale;
            scale.x = value;
            charObj.transform.localScale = scale;
        }
    }

    public void ChangeHeight(float value)
    {
        foreach (GameObject charObj in characters)
        {
            Vector3 scale = charObj.transform.localScale;
            scale.y = value;
            charObj.transform.localScale = scale;
        }
    }
}