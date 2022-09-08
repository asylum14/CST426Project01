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
    // Start is called before the first frame update
    void Start()
    {
        startPhrasing(filename);
    }

    void startPhrasing(string file)
    {
        string laPath = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Scripts/", file);
        using StreamReader sr = new StreamReader(laPath);
        {
            string line = "";
            int xPlace = 0;
            while ((line = sr.ReadLine()) != null)
            {
               int aNumber = int.Parse(sr.ReadLine());
               int type = int.Parse(sr.ReadLine());
               spawnCard(line, aNumber, type, xPlace);
               xPlace += 2;
            }
            sr.Close();
        }
    }

    void spawnCard(string n, int AN, int t, int x)
    {
        //GameObject currentGhost;
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

        Vector3 place = new Vector3((float) x, 0f, 0f);
        currentGhost.GetComponent<Card>().setName(n);
        currentGhost.GetComponent<Card>().setNumber(AN);
        Instantiate(currentGhost, place, Quaternion.identity);
    }
}
