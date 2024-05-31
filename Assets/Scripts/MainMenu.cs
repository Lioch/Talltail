using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string[] sceneNames;
    SceneController sceneController;

    public void StartGame(int versionNumber)
    {
        sceneController.SetNextScene(sceneNames[versionNumber]);
        sceneController.EndScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
