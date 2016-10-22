using UnityEngine;

//To use UI management
using UnityEngine.UI;

//Fore Scene Management
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int enemyCount;
	public GameObject enemy;
    public Text Health;
    public Text Score;
    public Text Hi_Score;
    public Text GameOver;
    public GameObject Player;
    public Button playAgain;

    // Private Instance Variables
    private int hp = 5;
    private int points = 0;
    private int highscore = 0;
    private bool playOnce = true;

    // Use this for initialization
    void Start () {
        //Spawns Enimies
        this._GenerateEnemies ();

        //Hides Text felids at begining of game
        this.Hi_Score.gameObject.SetActive(false);
        this.GameOver.gameObject.SetActive(false);
        this.playAgain.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate enemies
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}

    //Displays the players HP
    public void DecreaseHP(int Decrease)
    {
        hp -= Decrease;
        Health.text = "HP: " + hp + "/5";
    }

    // Displays Scores
    public void IncreaseScore(int Increase)
    {
        points += Increase;
        Score.text = "SCORE:" + points;
        if (hp <= 0)
        {
            if (highscore < points)
            {
                // This is to show the final score once
                if (playOnce == true)
                { 
                    highscore = points;
                    Hi_Score.text = "Final Score:" + highscore;
                    playOnce = false;
                }
            }
        }
    }

    //This runs at the end of a game
    public void _endGame()
    {
        //This hides UI elements
        this.Player.SetActive(false);
        this.Health.gameObject.SetActive(false);
        this.Score.gameObject.SetActive(false);
        this.Hi_Score.gameObject.SetActive(true);
        this.GameOver.gameObject.SetActive(true);
        this.playAgain.gameObject.SetActive(true);
    }

    //Runs when the play again button is clicked
    public void playAgain_Click()
    {
        SceneManager.LoadScene("Main");
        points = 0;
    }
}
