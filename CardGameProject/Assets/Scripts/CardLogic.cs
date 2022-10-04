using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLogic : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastThing raycastThing;
    
    void Start()
    {
        raycastThing = gameObject.GetComponent<RaycastThing>();
    }

    public int runCalulations()
    {
        int value = 0;
        foreach(GameObject GO in raycastThing.selectedCards)
        {
            Card placement = GO.GetComponent<Card>();
            value += placement.getNumber();
        }
        return value;
    }

    public int typeLogic()
    {
        int target = runCalulations();
        int results;
        if ((target >= 6 && target <= 9) || (target >= 15 && target <= 17) || (target == 34 || target == 35))
        {
            results = 1;
            return results;
        }
        //44 is the highest possible number
         else if ((target >= 21 && target <= 31) || (target >= 39 && target <= 44))
        {
            results = 8;
            return results;
        }

        else if ((target == 5 || target == 14) || (target == 32 || target == 33))
        {
            results = 5;
            return results;
        }

        else if ((target == 9 || target == 17) || target == 35)
        {
            results = 6;
            return results;
        }

        else if ((target == 10 || target == 18) || target == 36)
        {
            results = 2;
            return results;
        }

        else if ((target == 3 || target == 11) || (target == 19 || target == 37))
        {
            results = 3;
            return results;
        }

        else if ((target == 4 || target == 12) || (target == 12 || target == 20) || target == 38)
        {
            results = 4;
            return results;
        }

        else if (target == 13 || target == 31)
        {
            results = 7;
            return results;
        }

        else
        {
            return 1;
        }
    }
}
