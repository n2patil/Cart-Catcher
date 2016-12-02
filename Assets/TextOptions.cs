using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextOptions : MonoBehaviour {

    public Text textUI;
    private int textIndex = 0;


    public static string[] questions = new string[]
    {
        "Pick 3 items that are a good source of Vitamin A.",
        "Pick 2 items that are a high source of fiber.",
        "Pick 3 items that are high source of protein."
    };

    public void Start()
    {

        UpdateText();


    }

    public void CycleOptions()
    {

        textIndex++;

        if (textIndex >= questions.Length)
        {

            textIndex = 0;

        }

        UpdateText();

    }

    public void UpdateText()
    {

        textUI.text = questions[textIndex];

    }
}
