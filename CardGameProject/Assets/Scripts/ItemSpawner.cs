using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

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
    [SerializeField] int cardsTaken;
    bool[] locationSlot;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        locationSlot = new bool[5];
        for (int c = 0; c < 5; c++)
        {
            locationSlot[c] = false;
            //Debug.Log(cardLocations[c].position);
        }
        startPhrasing(filename);
        text.text = "DRAW " + cardsRemaining();
    }

    public void removeCard(GameObject target)
    {
        Vector3 lastPostion = target.transform.position;
        for (int c = 0; c < 5; c++)
        {
            if (lastPostion.Equals(cardLocations[c].position))
            {
                locationSlot[c] = false;
                //Debug.Log("Slot " + c + " is opened");
                break;
            }
        }
        Destroy(target);
    }

    void startPhrasing(string file) // TODO: Find a way to sperate this and find a way to add new elements
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
               Debug.Log(line + " " + aNumber + " " + type + " was read.");
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
            locationSlot[c] = true;
            cardsTaken++;
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

    public void shuffle() 
    {
        List<GameObject> tempDeck = new List<GameObject>();
        bool[] locations = new bool[deck.Capacity]; 
        cardsTaken = 0;
        for (int c = 0; c < deck.Capacity; c++)
        {
            locations[c] = false;
        }

        for (int c = 0; c < deck.Capacity; c++)
        {
            int currentLocation = Random.Range(0, (int) deck.Capacity - 1);
            while(locations[currentLocation] == true)
            {
                Debug.Log("THIS WAS TRIGGERED at " + currentLocation);
                if (locations[currentLocation] == true)
                {
                    currentLocation = Random.Range(0, deck.Capacity);
                }
            }
            tempDeck.Add(deck[currentLocation]);
            locations[currentLocation] = true;
        }
        deck = tempDeck;
        //text.text = "DRAW " + cardsRemaining();
    }
    
    public void spawnCard(GameObject card, Vector3 location)
    {
        if (cardsTaken >= deck.Capacity)
        {
            return;
        }

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

    public void spawnNewCard() // this needs to change too
    {
        if (cardsTaken >= deck.Capacity)
        {
            Debug.Log("FAIL CONDITION 1: NO CARDS");
            return;
        }

        switch(deck[cardsTaken].GetComponent<Card>().getType())
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

        bool slotAva = false;
        int slotLocation;
        for (slotLocation = 0; slotLocation < 5; slotLocation++)
        {
            if (locationSlot[slotLocation] == false)
            {
                slotAva = true;
                break;
            }
        }

        if (slotAva)
        {
            locationSlot[slotLocation] = true;
            Instantiate(deck[cardsTaken], cardLocations[slotLocation].position, Quaternion.identity);
            cardsTaken++;
            text.text = "DRAW " + cardsRemaining();
            return;
        }
        Debug.Log("FAIL CONDITION 2: No slots avaliable");
    }

    public int cardsRemaining()
    {
        return deck.Count - cardsTaken;
    }
    
}
