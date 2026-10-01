using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadScene(string sceneName) // sceneName parameter allows for loading different scenes using the same code
    {
        SceneManager.LoadScene(sceneName); // Load scene
    }
}
    