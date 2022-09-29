using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastThing : MonoBehaviour
{
    public ItemSpawner boss;
    public SampleUI ui;
    public List<GameObject> selectedCards;
    Camera camera;
    RaycastHit hit;
    Ray ray;
    ItemSpawner ItemSpawner;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        ItemSpawner = this.gameObject.GetComponent<ItemSpawner>();
    }

    public void playCards()
    {
        foreach (GameObject GO in selectedCards)
        {
            ItemSpawner.removeCard(GO);
        }
        selectedCards.Clear();
        ui.resetText();
    }

    void addOnText()
    {
        int counter = 0;
        Debug.Log(selectedCards.Count);
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
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            string name = hit.transform.gameObject.GetComponent<Card>().getName();
            int number = hit.transform.gameObject.GetComponent<Card>().getNumber();
            //ui.setElementText(number, name);
            if (Input.GetMouseButtonDown(0))
            {
                var target = hit.transform.GetComponent<Card>();
                target.toggleOutline(); //hit.transform.gameObject.GetComponent<Card>().toggleOutline();
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
                //boss.removeCard(hit.transform.gameObject);
            }
        }

        // }
    }
}
