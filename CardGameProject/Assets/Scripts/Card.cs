using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public int atmoicNumber;
    public string elementName;
    public int type;

    public void setName(string n)
    {
        elementName = n;
    }
    
    public void setNumber(int n)
    {
        atmoicNumber = n;
    }

    public void setType(int t)
    {
        type = t;
    }

    public string getName()
    {
        return elementName;
    }

    public int getNumber()
    {
        return atmoicNumber;
    }

    public int getType()
    {
        return type;
    }
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
