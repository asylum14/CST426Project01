using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public string filename;
    public GameObject nonMetal;
    public GameObject nobalGas;
    public GameObject basicMetal;
    public GameObject halogen;
    public GameObject semimetal;
    public GameObject aMetal;
    public GameObject aEarth;
    public GameObject  transition;
    GameObject currentGhost;
    public List<GameObject> deck;
    public List<Transform> cardLocations;
    // Start is called before the first frame update
    void Start()
    {
        //deck = new List<Card>();
        startPhrasing(filename);
    }

    void startPhrasing(string file)
    {
        string laPath = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Scripts/", file);
        using StreamReader sr = new StreamReader(laPath);
        {
            string line = "";
            int xPlace = 0;
            int loopTimer = 0;
            while ((line = sr.ReadLine()) != null)
            {
               int aNumber = int.Parse(sr.ReadLine());
               int type = int.Parse(sr.ReadLine());
               //spawnCard(line, aNumber, type, xPlace);
               putCardToDeck(line, aNumber, type);
               xPlace += 2;
            }
            sr.Close();
        }
        shuffle();

        for (int c = 0; c < 5; c++)
        {
            spawnCard(deck[c], cardLocations[c].position);
        }
    }

    void putCardToDeck(string n, int AN, int t)
    {
        switch(t)
        {
            case 1:
                currentGhost = nonMetal;
                break;

            case 2:
                currentGhost = nobalGas;
                break;
            
            case 3:
                currentGhost = aMetal;
                break;

            case 4:
                currentGhost = aEarth;
                break;

            case 5:
                currentGhost = semimetal;
                break;

            case 6:
                currentGhost = halogen;
                break;

            case 7:
                currentGhost = basicMetal;
                break;

            case 8:
                currentGhost = transition;
                break;

            default: break;
        }
        currentGhost.GetComponent<Card>().setName(n);
        currentGhost.GetComponent<Card>().setNumber(AN);
        deck.Add(currentGhost);
    }

    void shuffle() // TODO: current issue with sorting that a element can be pulled twice
    {
        List<GameObject> tempDeck = new List<GameObject>();
        bool[] locations = new bool[deck.Capacity]; 
        for (int c = 0; c < deck.Capacity; c++)
        {
            locations[c] = false;
        }

        for (int c = 0; c < deck.Capacity; c++)
        {
            int currentLocation = Random.Range(0, deck.Capacity);
            while(locations[currentLocation] == true)
            {
                Debug.Log("THIS WAS TRIGGERED at " + currentLocation);
                if (locations[currentLocation] == true)
                {
                    currentLocation = Random.Range(0, deck.Capacity);
                }
            }
            tempDeck.Add(deck[currentLocation]);
        }
        deck = tempDeck;
    }
    
    void spawnCard(GameObject card, Vector3 location)
    {
        switch(card.GetComponent<Card>().getType())
        {
            case 1:
                currentGhost = nonMetal;
                break;

            case 2:
                currentGhost = nobalGas;
                break;
            
            case 3:
                currentGhost = aMetal;
                break;

            case 4:
                currentGhost = aEarth;
                break;

            case 5:
                currentGhost = semimetal;
                break;

            case 6:
                currentGhost = halogen;
                break;

            case 7:
                currentGhost = basicMetal;
                break;

            case 8:
                currentGhost = transition;
                break;

            default: break;
        }
        Instantiate(card, location, Quaternion.identity);
    }

    void spawnCard(string n, int AN, int t, int x) // this needs to change too
    {
        switch(t)
        {
            case 1:
                currentGhost = nonMetal;
                break;

            case 2:
                currentGhost = nobalGas;
                break;
            
            case 3:
                currentGhost = aMetal;
                break;

            case 4:
                currentGhost = aEarth;
                break;

            case 5:
                currentGhost = semimetal;
                break;

            case 6:
                currentGhost = halogen;
                break;

            case 7:
                currentGhost = basicMetal;
                break;

            case 8:
                currentGhost = transition;
                break;

            default: break;
        }

        Vector3 place = new Vector3((float) x, 0f, 0f); // this can change based on the location of the card slot
        currentGhost.GetComponent<Card>().setName(n);
        currentGhost.GetComponent<Card>().setNumber(AN);
        deck.Add(currentGhost);

        Instantiate(currentGhost, place, Quaternion.identity);
    }

    
}
