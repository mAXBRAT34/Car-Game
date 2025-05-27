using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(RestartLevel); 
    }

    private void RestartLevel()
    {
        Debug.Log("📌 Перезапуск уровня...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restartem
    }
}
