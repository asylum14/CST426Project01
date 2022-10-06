using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CardMan : MonoBehaviour
{
    // Start is called before the first frame update
    //public List<Card> deck;
    //public List<Card> hand;
    public string filename;

    //I want to do a instance thing just like what I did in Project2D
    //It will grab the text file and read the contents of the file and adds it into the card
    // then on the initial draw phase draw 5 cards from the deck then its placed into your hand
    void Start()
    {
        Debug.Log(Application.dataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
