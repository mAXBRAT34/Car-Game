using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
