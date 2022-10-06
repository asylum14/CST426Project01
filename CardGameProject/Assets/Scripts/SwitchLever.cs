using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLever : MonoBehaviour
{
    public void getMEOUTOFHERE() // Squidward KARMA
    {
        SceneManager.LoadScene("Standby", LoadSceneMode.Single);
    }

    public void getMEBACKINTHERE() // Gameplay
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    public void getTHEHELLOUTOFHERE() // exit
    {
        Application.Quit();
    }
}
