using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()//IZIET
    {
        Debug.Log("Iziet...");
        Application.Quit();
    }
}
