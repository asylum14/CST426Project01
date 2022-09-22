using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private int playerScore;
    private int compScore;
    private ArrayList Deck;
    
    //Testing having multiple cards in a deck
    private ArrayList possiblePlayerCards;
    private ArrayList possibleEnemyCards; 
    private ArrayList compDeck;
    private ArrayList Hand;
    private ArrayList EnemyHand;
    private int turn;
    public Transform handPosition;
    public Transform enemyHandPosition;
    public GameObject testCard;
    private bool ableToDraw;
    private int numCardInstances;
    
    //card the Player uses
    private Card playerActiveCard;
    //card the Computer uses
    private Card enemyActiveCard;
    private int click_cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        numCardInstances = 0;
        click_cooldown = 0;
        ableToDraw = false;
        turn = 0;
        playerScore = 0;
        compScore = 0;
        possiblePlayerCards = new ArrayList();
        Hand = new ArrayList();
        EnemyHand = new ArrayList();
        possiblePlayerCards.Add(new Card(0, "Hydrogen", "BASIC", 1, 0));
        possiblePlayerCards.Add(new Card(1, "Helium", "NOBLE", 1, 0));
        possiblePlayerCards.Add(new Card(1, "Lithium", "ALKALI_METAL", 1, 0));
        possiblePlayerCards.Add(new Card(1, "Beryllium", "ALKALINE_METAL", 1, 0));
        
        possibleEnemyCards = new ArrayList();
        possibleEnemyCards.Add(new Card(0, "Hydrogen", "BASIC", 1, 0));
        possibleEnemyCards.Add(new Card(1, "Helium", "NOBLE", 1, 0));
        possibleEnemyCards.Add(new Card(1, "Lithium", "ALKALI_METAL", 1, 0));
        possibleEnemyCards.Add(new Card(1, "Beryllium", "ALKALINE_METAL", 1, 0));
        Deck = new ArrayList();
        compDeck = new ArrayList();
        int r;
        int er;
        for(int i =0; i<20; i++){
            r = Random.Range(0, possiblePlayerCards.Count);
            er = Random.Range(0, possibleEnemyCards.Count);
            Deck.Add(possiblePlayerCards[r]);
            compDeck.Add(possibleEnemyCards[er]);
        }
        
        //shuffle(Deck);
        drawCards(Deck,5,Hand);
        drawCards(compDeck, 5,EnemyHand);
        Vector3 pos = handPosition.transform.position;
        Vector3 compPos = enemyHandPosition.transform.position;
        Vector3 hand_pos;
        GameObject card_instance;
        
        
        //Initial card draw for Player
        for(int i = 0; i < Hand.Count; i++){
            Card c = (Card)Hand[i];
            card_instance = Instantiate(testCard, new Vector3(pos.x + (5*i), pos.y, pos.z), 
                Quaternion.identity);
            numCardInstances++;
            card_instance.GetComponent<Card>().setData(c.getCost(),c.getName(),c.getType(),c.getValue(),c.getOwner());
            
            if (card_instance.GetComponent<Card>().getName() == "Hydrogen")
            {
                card_instance.GetComponent<Renderer>().material.color = Color.green;
            }
            switch(card_instance.GetComponent<Card>().getName()) 
            {
                case "Hydrogen":
                    card_instance.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case "Helium":
                    card_instance.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case "Lithium":
                    card_instance.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case "Beryllium":
                    card_instance.GetComponent<Renderer>().material.color = Color.cyan;
                    break;
                default:
                    //throw error if card is not implemented
                    print("CARD DOESNT EXIST");
                    break;
            }
            Hand[i]=card_instance.GetComponent<Card>();
        }
        
        //Initial card draw for Computer Player
        for(int i = 0; i < EnemyHand.Count; i++)
        {
            Card c = (Card)EnemyHand[i];
            card_instance = Instantiate(testCard, new Vector3(compPos.x + (5 * i), compPos.y, compPos.z),
                Quaternion.identity);
            
            card_instance.GetComponent<Renderer>().material.color = Color.red;
            card_instance.GetComponent<Card>().setData(c.getCost(),c.getName(),c.getType(),c.getValue(),c.getOwner());
            EnemyHand[i] = card_instance.GetComponent<Card>();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //// If the mouse clicks on a card run some code and it's the player's turn
        if (Input.GetMouseButton(0) && (turn % 2 == 0) && click_cooldown<0){
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay,out hit)){
                GameObject objectHit = hit.transform.gameObject;

                if (objectHit.name == "CardPrefab(Clone)" && objectHit.GetComponent<Card>().getOwner() == 0 )
                {
                    click_cooldown = 100;
                    Card hitCard = objectHit.GetComponent<Card>();
                    playerActiveCard = hitCard.Clone();
                    playCard(playerActiveCard);
                    for (int i = 0; i < Hand.Count; i++)
                    {
                        Card temp = (Card)Hand[i];
                        if (hitCard.getName() == temp.getName())
                        {
                            Hand.RemoveAt(i);
                            break;
                        }
                    }
                   
                    
                    Destroy(objectHit);
                    numCardInstances--;
                    moveCards(Hand,handPosition.transform.position);
                    turn++;
                }
                
            }
    
    
        }
        //if space is pressed and player is able to draw 
        if (ableToDraw && Input.GetKeyDown("space"))
        {
            drawCards(Deck, 1,Hand);
            moveCards(Hand,handPosition.transform.position);
            ableToDraw = false;
        }
        
        //TODO add an option for Gaining Energy

        if(turn % 2 == 1){
            AiTurn();
            resolveScore(playerActiveCard,enemyActiveCard);
            print("Score\n\t Player: " + playerScore + " Computer: " + compScore);
            ableToDraw = true;
        }

        click_cooldown--;
    }

    void drawCards(ArrayList deck, int cardsDrawn, ArrayList h){
        for(int i = 0; i<cardsDrawn; i++)
        {
            Card c = (Card) deck[i]; 
            h.Add(c);
            deck.RemoveAt(0);
        }
        
    }

    void resolveScore(Card p, Card c)
    {
        if (p.getType() == c.getType())
        {
            if (p.getValue() > c.getValue())
            {
                print("Player Wins Round");
                playerScore++;
            }
            else if (p.getValue() < c.getValue())
            {
                print("Computer Wins Round");
                compScore++;
            }
            else
            {
                print("Round is a Draw");
            }
        }
        else if ((p.getType() == "NOBLE" && c.getType() != "ALKALI_METAL")
                 || (p.getType() == "ALKALI_METAL" && c.getType() != "ALKALINE_METAL")
                 || (p.getType() == "ALKALINE_METAL" && c.getType() != "NOBLE"))
        {
            print("Player Wins Round");
            playerScore++;
        }
        else if ((p.getType() == "NOBLE" && c.getType() == "ALKALI_METAL")
                 || (p.getType() == "ALKALI_METAL" && c.getType() == "ALKALINE_METAL")
                 || (p.getType() == "ALKALINE_METAL" && c.getType() == "NOBLE")
                 || (p.getType() == "BASIC"))
        {
            print("Computer Wins Round");
            compScore++;
        }
    }

    void AiTurn(){
        Debug.Log("AI makes his turn");
        //The AI should make a choice to either draw or gain an energy point. 
        int r = Random.Range(0, EnemyHand.Count);
        print("Random " + EnemyHand.Count);
        turn++;
        Card g = (Card)EnemyHand[r];
        enemyActiveCard = g.Clone();
        Destroy(g.gameObject);
        EnemyHand.RemoveAt(r);
        playCard(enemyActiveCard);
        moveCards(EnemyHand, enemyHandPosition.transform.position);
    }

    void playCard(Card c)
    {
        print("Playing " + c.getName() + " with a value of " + c.getValue() + " and a type of " + c.getType());
    }

    void moveCards(ArrayList h, Vector3 v)
    {
        while (h.Contains(null))
        {
            h.Remove(null);
        }
        
        print("num of cards: " + numCardInstances);
        print("hCOunt " + h.Count);
        for (int i = numCardInstances; i < h.Count; i++)
        {

            Vector3 pos = handPosition.transform.position;
            Card c = (Card)h[i];
            GameObject card_instance = Instantiate(testCard, new Vector3(pos.x + (5*i), pos.y, pos.z), 
                Quaternion.identity);
            numCardInstances++;
            card_instance.GetComponent<Card>().setData(c.getCost(),c.getName(),c.getType(),c.getValue(),c.getOwner());
            
            switch(card_instance.GetComponent<Card>().getName()) 
            {
                case "Hydrogen":
                    card_instance.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case "Helium":
                    card_instance.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case "Lithium":
                    card_instance.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case "Beryllium":
                    card_instance.GetComponent<Renderer>().material.color = Color.cyan;
                    break;
                default:
                    //throw error if card is not implemented
                    print("CARD DOESNT EXIST");
                    break;
            }
            Hand[i]=card_instance.GetComponent<Card>();
            
        }

        int index = 0;
        foreach (var c in h) {
            Card temp = (Card)c;
            if (temp != null)
            {
                temp.transform.position = new Vector3(v.x + (5*index), v.y, v.z);
            }
            


            index++;
        }
    }
}


