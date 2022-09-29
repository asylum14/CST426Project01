using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testOL : MonoBehaviour
{
    // Start is called before the first frame update
    double timer;
    Outline drawOutliner;
    void Start()
    {
        drawOutliner = gameObject.GetComponent<Outline>();
        drawOutliner.OutlineMode = Outline.Mode.OutlineAll;
        drawOutliner.OutlineColor = Color.black;
        drawOutliner.OutlineWidth = 6f;
        timer = 0;
        drawOutliner.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 6)
        {
            if (drawOutliner.enabled)
            {
                drawOutliner.enabled = false;
                timer = 0;
            }

            else 
            {
                drawOutliner.enabled = true;
                timer = 0;
            }
        }

        timer += Time.deltaTime;
        Debug.Log(timer);
    }
}
