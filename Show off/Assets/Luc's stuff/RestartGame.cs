using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public string sceneToBeLoaded;
    public void Load()
    {
        SceneManager.LoadScene(sceneToBeLoaded);
    }
}
