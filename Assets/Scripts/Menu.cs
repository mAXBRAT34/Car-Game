using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeScene(string Menu)
    {
        SceneManager.LoadScene(Menu);//MENU
    }
}
