using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [HideInInspector]
    public int score;
    private int hiScore;
    public float GameTime;
    private float realTime;

    public enum GameMode
    {
        title,
        game,
        end
    }

    private GameMode gameMode;

    public List<MoleHole> allMoles;

    public TextMesh titleText;
    public TextMesh instructionsText;
    public TextMesh scoreText;
    public TextMesh hiScoreText;
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Cursor.visible = false;
    }
   

    // Update is called once per frame
    void Update()
    {
        switch (gameMode)
        {
            case GameMode.title:
                if (Input.GetMouseButton(0))
                {
                    StartGame();
                }
                break;
            case GameMode.game:
                realTime -= Time.deltaTime;
                scoreText.text = "Score: " + score.ToString("00000");
                if (realTime <= 0)
                {
                   EndGame();
                }
                break;
            case GameMode.end:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    StartGame();
                }
                break;
        }
        
    }

    void StartGame()
    { 
    realTime = GameTime;
        gameMode = GameMode.game;
        instructionsText.gameObject.SetActive(false);

        //initialize all moles!
        foreach (MoleHole thisMole in allMoles)
        {
            thisMole.state = MoleHole.MoleState.down;
            thisMole.Hide();
        }
    }

    void EndGame()
    {
        gameMode = GameMode.end;
        foreach (MoleHole thisMole in allMoles)
        {
             thisMole.OnGameEnd();
                    
        }
        
        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = "Hi-Score: " + hiScore.ToString("00000");
        }

        score = 0;

        instructionsText.text = "Press R to play again!";
        instructionsText.gameObject.SetActive(true);
    }

    public GameMode GetGameMode()
    {
        return gameMode;
    }
    
}
