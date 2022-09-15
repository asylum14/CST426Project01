using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //for testing I will just add deck,grave, and actions 

    public TextMeshProUGUI deckSize;
    
    public TextMeshProUGUI graveSize;

    public TextMeshProUGUI actionPoints; 
    
    public int deck = 20; //Deck starting size, this is temp

    public int grave = 0; //Graveyard should start at 0 

    public int actions = 3; //Current testing will be done with player able to perform 3 actions

    public int pScore;

    public int eScore;

    public int gold = 50; //For testing allow player to start with gold.
    // Start is called before the first frame update
    
    //TODO 1: Link everything up, probably with the game manager 
    //TODO 2: Redo start, since it's really about the start of each fight, not just start of game
    //TODO 3: Set up the remaining ui things, this may create more todos.
    void Start()
    {
        deckSize.SetText($"{deck}");
        graveSize.SetText($"{grave}");
        actionPoints.SetText($"{actions}/3");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //For simplicity I think this should be called whenever we draw, i.e at start of turn and when a card allows the player to draw a card.
    private void drawCard()
    {
        deck--;
        deckSize.SetText($"{deck}");
    }
    
    //As with the drawCard function we can just call this after a card is played or if the player has to discard a card.
    private void toGrave()
    {
        grave++;
        graveSize.SetText($"{grave}");
    }

    private void useAction(int amount)
    {
        actions = actions - amount; // We need to see how many of the points are used by a card.
        actionPoints.SetText($"{actions}");
    }
}
