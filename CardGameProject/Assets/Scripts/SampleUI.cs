using UnityEngine;
using TMPro;
public class SampleUI : MonoBehaviour
{
    private TextMeshProUGUI someText;
    void Start()
    {
        someText = GetComponent<TextMeshProUGUI>();
        someText.text = "";
        actualText = "";
    }

    public void setElementText(int an, string text)
    {
        string number = an.ToString();
        someText.text = (number + " " + text); 
        actualText = someText.text;
    }

    public void setText(string text)
    {
        someText.text = text;
        actualText = text;
    }

    public void resetText()
    {
        someText.text = "";
        actualText = "";
    }

    public void addText(string placement)
    {
        someText.text += placement;
        actualText += placement;
    }

    public int getTextLength()
    {
        return actualText.Length;
    }

    public string getText()
    {
        return actualText;
    }

    public string getText()
    {
        return someText.text;
    }
}
