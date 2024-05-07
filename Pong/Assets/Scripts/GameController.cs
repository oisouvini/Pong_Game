using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool inPlay = false;
    bool gameOver = false;

    public int scoreOne;
    public int scoreTwo;

    [SerializeField] int scoreToWin;


    public Text textOne;
    public Text textTwo;

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Text WinnerText;


    private void OnEnable()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(inPlay == false && gameOver !=true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                inPlay = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene (0);
        }*/
        
        winner();
        
    }

    void winner()
    {
        if(!gameOver)
        {
            if(scoreOne >= scoreToWin)
            {
                gameOver = true;
                WinnerText.text = "Player 1 Wins";
                GameOverPanel.SetActive (true);
            }
             if(scoreTwo >= scoreToWin)
            {
                gameOver = true;
                WinnerText.text = "Player 2 Wins";
                GameOverPanel.SetActive (true);
            }
        }
    }
}
