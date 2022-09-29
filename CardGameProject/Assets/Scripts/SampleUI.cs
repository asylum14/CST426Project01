using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SampleUI : MonoBehaviour
{
    private TextMeshProUGUI someText;
    private int anGrabber;
    // Start is called before the first frame update
    void Start()
    {
        anGrabber = 0;
        someText = GetComponent<TextMeshProUGUI>();
        someText.text = "";
    }

    public void setElementText(int an, string text)
    {
        string number = an.ToString();
        someText.text = (number + " " + text); 
    }

    public void setText(string text)
    {
        someText.text = text;
    }

    public void resetText()
    {
        someText.text = "";
    }

    public void addText(string placement)
    {
        someText.text += placement;
    }
}
