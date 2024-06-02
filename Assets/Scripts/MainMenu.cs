using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] string[] sceneNames;

    public void StartGame(int versionNumber)
    {
        Debug.Log($"Loading scene with name: {sceneNames[versionNumber]}");
        sceneController.SetNextScene(sceneNames[versionNumber]);
        sceneController.EndScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
