using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void NewGame()
    {
        SaveLevel.instance.Save(false);
        SceneManager.LoadScene("SelectLevel");
    }

    public void Settings()
    {
        PauseMenuManager.instance.Pause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
