using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int cost;
    private string name;
    private string type;
    private int value;

    private int owner;
    
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    public Card(int cost, string name, string type, int value, int owner)
    {
        this.cost = cost;
        this.name = name;
        this.type = type;
        this.value = value;
        this.owner = owner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPrefab(){
        return cardPrefab;
    }

    public int getCost()
    {
        return cost;
    }

    public string getName()
    {
        return name;
    }

    public string getType()
    {
        return type;
    }

    public int getValue()
    {
        return value;
    }

    public int getOwner()
    {
        return owner;
    }

    public void setData(int cost, string name, string type, int value, int owner )
    {
        this.cost = cost;
        this.name = name;
        this.type = type;
        this.value = value;
        this.owner = owner;
    }


    public  override string ToString()
    {
        return "Card Cost: " + this.cost + "\nCard Name: " + this.name + "\nCard Type: " + this.type +
               "\nCard Value: "+ this.value+"\nCard Owner: "+this.owner;
    }
    public Card Clone()
    {
        return new Card(cost, name, type, value, owner);
    }
}
