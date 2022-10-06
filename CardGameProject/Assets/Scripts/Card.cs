using UnityEngine;

public class Card : MonoBehaviour
{
    public int atmoicNumber;
    public string elementName;
    public int type;
    Outline outlinePencil; // For more infomation please visit the QuickOutline folder

    void Start()
    {
        outlinePencil = gameObject.GetComponent<Outline>();
        outlinePencil.OutlineColor = Color.white;
        outlinePencil.OutlineWidth = 7f;
        outlinePencil.enabled = false;
    }
    
    public void setName(string n)
    {
        this.elementName = n;
    }
    
    public void setNumber(int n)
    {
        this.atmoicNumber = n;
    }

    public void setType(int t)
    {
        this.type = t;
    }

    public string getName()
    {
        return this.elementName;
    }

    public int getNumber()
    {
        return this.atmoicNumber;
    }

    public int getType()
    {
        return this.type;
    }
    
    public void toggleOutline()
    {
        if (outlinePencil.enabled)
        {
            outlinePencil.enabled = false;
            return;
        }
        outlinePencil.enabled = true;
    }

    public bool getOutlineState()
    {
        return outlinePencil.enabled;
    }
}
