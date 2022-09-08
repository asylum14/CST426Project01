using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private ArrayList Deck;
    private ArrayList Hand;
    private ArrayList EnemyHand;
    private int turn;
    public Transform handPosition;
    public GameObject testCard;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        Deck = new ArrayList();
        for(int i =0; i<20; i++){
            Deck.Add(new Card());
        }
        //shuffle(Deck);
        Hand = drawCards(Deck,5);
        Vector3 pos = handPosition.transform.position;
        for(int i = 0; i < Hand.Count; i++){
            Instantiate(testCard, new Vector3(pos.x + (5*i), pos.y, pos.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Deck: "+Deck.ToString());

       //// If the mouse clicks on a card run some code and it's the player's turn
        if (Input.GetMouseButton(0) && (turn%2 == 0)){
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay,out hit)){
                GameObject objectHit = hit.transform.gameObject;

                if (objectHit.name == "CardPrefab(Clone)"){
                    playCard();
                    Destroy(objectHit);
                    turn++;
                }
                
            }
    
    
        }

        if(turn %2 == 1){
            AiTurn();
        }
    }

    ArrayList drawCards(ArrayList deck, int cardsDrawn){
        ArrayList output = new ArrayList();
        for(int i = 0; i<cardsDrawn; i++){
            output.Add(Deck[0]);
            Deck.Remove(0);
        }
        
        return output;
    }

    void playCard(){
        Debug.Log("Hit card");
    }
    void AiTurn(){
        Debug.Log("AI makes his turn");
        turn++;
    }
}
