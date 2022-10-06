using UnityEngine;

public class CardLogic : MonoBehaviour
{
    RaycastThing raycastThing; // Raycast
    
    void Start()
    {
        raycastThing = gameObject.GetComponent<RaycastThing>();
    }

    public int runCalulations() // sums up the total of AN from the selected cards and returns the total
    {
        int value = 0;
        foreach(GameObject GO in raycastThing.selectedCards)
        {
            Card placement = GO.GetComponent<Card>();
            value += placement.getNumber();
        }
        return value;
    }

    public int typeLogic() // calls runCalulations and give the "card" a type
    {
        int target = runCalulations();
        int results;
        if ((target >= 6 && target <= 8) || (target >= 15 && target <= 16) || target == 34)
        {
            results = 1;
            return results;
        }

        //49 is the highest possible number
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

        else if ((target == 10 || target == 18) || (target == 2|| target == 36))
        {
            results = 2;
            return results;
        }

        else if ((target == 3 || target == 11) || (target == 19 || target == 37))
        {
            results = 3;
            return results;
        }

        else if ((target == 4 || target == 12) || (target == 38 || target == 20))
        {
            results = 4;
            return results;
        }

        else if ((target == 13 || target == 31) || target == 49)
        {
            results = 7;
            return results;
        }

        else
        {
            return 1;
        }
    }

    public string returnType(int r) // returns a string based on its type
    {
        string target;
        switch(r)
        {
            case 1:
            {
                target = "Non-Metal";
                break;
            }

            case 2:
            {
                target = "Noble Gas";
                break;
            }

            case 3:
            {
                target = "Alkali Metal";
                break;
            }

            case 4:
            {
                target = "Alkaline Earth Metal";
                break;
            }

            case 5:
            {
                target = "Semimetal";
                break;
            }

            case 6:
            {
                target = "Halogen";
                break;
            }

            case 7:
            {
                target = "Basic Metal";
                break;
            }

            case 8:
            {
                target = "Transition Metal";
                break;
            }

            default: 
                target = "";
                break;
        }

        return target;
    }
}
