using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void loadScene(string sceneNameParam)
    {
        SceneManager.LoadScene(sceneNameParam);
    }

    public void closeGame()
    {
        //only quits when built not in the editor
        Application.Quit();
    }

}
