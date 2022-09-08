using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastThing : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        
        //for now
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, 100f))
            {
                string name = hit.transform.gameObject.GetComponent<Card>().getName();
                int number = hit.transform.gameObject.GetComponent<Card>().getNumber();
                Debug.Log(number + " " + name);
            }

        }
    }
}
