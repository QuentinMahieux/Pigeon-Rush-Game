using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager instance;

    public bool isNoPause;
    public bool isCursor;
    public GameObject pauseMenu;
    public GameObject secondaireMenu;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one PauseMenuManager in scene!");
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        pauseMenu.SetActive(false);
        secondaireMenu.SetActive(false);
        
        if (isNoPause) secondaireMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isPause && !pauseMenu.activeSelf && !secondaireMenu.activeSelf)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.isPause && pauseMenu.activeSelf && !secondaireMenu.activeSelf)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.isPause && !pauseMenu.activeSelf && secondaireMenu.activeSelf)
        {
            ChangeMenu();
        }
    }

    public void QuitLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
        
        SceneManager.LoadScene("SelectLevel");
    }
    
    public void QuitGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
        
        MetroController.instance.SetCoordonee();
        SceneManager.LoadScene("Scenes/MainScene");
    }
    

    public void Resume()
    {
        pauseMenu.SetActive(false);
        
        CursorState();
        
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
    }
    
    public void Pause()
    {
        GameManager.instance.isPause = true;
        
        pauseMenu.SetActive(true);
        secondaireMenu.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Time.timeScale = 0;
    }
    
    public void ChangeMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        secondaireMenu.SetActive(!secondaireMenu.activeSelf);
        Time.timeScale = 0;
    }
    
    void CursorState()
    {
        if (isCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
