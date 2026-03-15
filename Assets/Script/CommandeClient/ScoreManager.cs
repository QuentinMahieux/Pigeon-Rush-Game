using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public GameObject interfaceGameObject;
    
    [Header("Interface Score")]
    [Header("Level Information")]
    public TMP_Text textLevelName;
    
    [Header("Score")]
    public TMP_Text textScore;
    public TMP_Text textBestScore;
    
    [Header("Stars")]
    public TMP_Text[] textStars;
    public Image[] imageStars;

    public Sprite starWin;
    public Sprite starLose;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one ScoreManager in scene!");
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        interfaceGameObject.SetActive(false);
    }

    public void AfficheScores(int score, LevelData levelData)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        interfaceGameObject.SetActive(true);
        textLevelName.text = levelData.levelName;
        
        textScore.text = score.ToString();
        
        SaveLevel.instance.NewScore(levelData.levelName, score);
        
        textBestScore.text = SaveLevel.instance.GetInt(levelData.levelName).ToString();

        for (int i = 0; i < textStars.Length; i++)
        {
            textStars[i].text = levelData.starsPallier[i].ToString();
            if (levelData.starsPallier[i] <= score)
            {
                imageStars[i].sprite = starWin;
            }
            else
            {
                imageStars[i].sprite = starLose;
            }
        }
    }

    public void CloseMenu()
    {
        LevelManager.instance.QuitLevel();
    }
}
