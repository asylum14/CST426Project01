using System.Collections.Generic;
using UnityEngine;

public class RaycastThing : MonoBehaviour
{
    public ItemSpawner boss; // as is
    public SampleUI ui; // as is
    public List<GameObject> selectedCards; // for selected cards that from the player has clicked  on
    public CardLogic cL; // external card logid
    Camera camera; // camera
    RaycastHit hit; // raycast
    Ray ray; // raycast
    ItemSpawner ItemSpawner; // card spawner
    double uiCounter = 0f; // ui counter
    // Start is called before the first frame update
    void Start() // set camera and itemspawner
    {
        camera = Camera.main;
        ItemSpawner = this.gameObject.GetComponent<ItemSpawner>();
        uiCounter = 0f;
    }

    public void playCards() // play selected cards, display total AN and combined type then resets selected cards
    {
        ui.resetText();
        uiCounter = 0f;
        ui.addText(cL.runCalulations() + " Type: " + cL.returnType(cL.typeLogic()));
        foreach (GameObject GO in selectedCards)
        {
            ItemSpawner.removeCard(GO);
        }
        selectedCards.Clear();
    }

    void addOnText() // for ui for adding on the text for selected cards
    {
        int counter = 0;
        foreach (GameObject GO in selectedCards)
        {
            string sample = GO.GetComponent<Card>().getName();
            string number = GO.GetComponent<Card>().getNumber().ToString();
            string masterText = number + " " + sample;
            if (counter != selectedCards.Count - 1)
            {
                masterText += " + ";
            }
            ui.addText(masterText);
            counter++;
        }
    }
   
    void Update()
    {
        //raycast logic
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            string name = hit.transform.gameObject.GetComponent<Card>().getName();
            int number = hit.transform.gameObject.GetComponent<Card>().getNumber();
            if (Input.GetMouseButtonDown(0))
            {
                var target = hit.transform.GetComponent<Card>();
                target.toggleOutline(); 
                if (target.getOutlineState())
                {
                    hit.transform.gameObject.tag = "Selected";
                    selectedCards.Add(hit.transform.gameObject);
                    ui.resetText();
                    addOnText();
                }

                else
                {
                    hit.transform.gameObject.tag = "Card";
                    selectedCards.Remove(hit.transform.gameObject);
                    ui.resetText();
                    addOnText();
                }
            }
        }

        //UI catch and reset
        if (ui.getText().Length > 0 && selectedCards.Count == 0)
        {
            if (uiCounter >= 5)
            {
                uiCounter = 0;
                ui.resetText();
            }
            else
            {
                uiCounter += Time.deltaTime;
            }
        }
    }
}
