using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int cost;
    private string name;
    private string type;
    private int value;
    
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
     cost = 0;
     name = "DEFAUlT_HYDROGEN";
     type = "DEFUALT_HALOGEN";
     value = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPrefab(){
        return cardPrefab;
    }
}
