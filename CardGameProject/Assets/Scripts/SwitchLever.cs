using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLever : MonoBehaviour
{
    public void getMEOUTOFHERE()
    {
        SceneManager.LoadScene("Standby", LoadSceneMode.Single);
    }

    public void getMEBACKINTHERE()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
