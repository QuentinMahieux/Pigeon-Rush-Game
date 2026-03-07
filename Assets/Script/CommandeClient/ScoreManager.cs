using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public GameObject interfaceGameObject;
    
    [Header("Interface Score")]
    [Header(" ")]
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

    void AfficheScores()
    {
        interfaceGameObject.SetActive(true);
        textLevelName.text = LevelManager.instance.levelData.levelName;
        
        textScore.text = LevelManager.instance.actualScore.ToString();
    }
}
