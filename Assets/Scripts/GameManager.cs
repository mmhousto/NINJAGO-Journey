using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.LEGO.Game;

public class GameManager : MonoBehaviour
{

        private Vector3 startPos;
        private Vector3 startRot;
        private int selectedChar;

        public GameObject[] playerPrefabs;

        public CinemachineVirtualCamera cam;

        public TextMeshProUGUI scoreText;

        private int[] highscores;

        private GameObject player;

        [SerializeField] private float score = 0;

        [SerializeField] private bool gameStarted = false;

        [SerializeField] private bool gameEnded = false;

        private void Awake()
        {
        gameEnded = true;
            


        }

        private void Start()
        {
            
            startPos = new Vector3(217.8066f, 1.4f, 268.3027f);
            startRot = new Vector3(0, 180f, 0);
            selectedChar = Random.Range(0, 9);
            score = 0.0f;
            player = Instantiate(playerPrefabs[selectedChar], startPos, Quaternion.Euler(startRot));
            cam.Follow = player.transform;
            cam.LookAt = player.transform;
            

            SceneManager.activeSceneChanged += EndGame;

            gameStarted = false;
            gameEnded = false;
            Time.timeScale = 0;


        highscores = new int[] { 
                PlayerPrefs.GetInt("Highscore", 0),
                PlayerPrefs.GetInt("Highscore2", 0),
                PlayerPrefs.GetInt("Highscore3", 0),
                PlayerPrefs.GetInt("Highscore4", 0),
                PlayerPrefs.GetInt("Highscore5", 0) 
            };

        }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= EndGame;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= EndGame;
    }

    public void StartGame()
        {
            Time.timeScale = 1;
            gameStarted = true;
            gameEnded = false;
            
        }

        private void Update()
        {
            scoreText.text = ((int)score).ToString();
            if (gameStarted && !gameEnded)
            {
                score += Time.deltaTime;
            }

            if (Events.GameOverEvent.Active)
            {
                EndGame();
            } else
            {
                gameEnded = false;
            }

        }

    public void EndGame()
    {
        gameEnded = true;
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", (int)score);
            PlayerPrefs.SetInt("Highscore2", highscores[0]);
            PlayerPrefs.SetInt("Highscore3", highscores[1]);
            PlayerPrefs.SetInt("Highscore4", highscores[2]);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore2", 0))
        {
            PlayerPrefs.SetInt("Highscore2", (int)score);
            PlayerPrefs.SetInt("Highscore3", highscores[1]);
            PlayerPrefs.SetInt("Highscore4", highscores[2]);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore3", 0))
        {
            PlayerPrefs.SetInt("Highscore3", (int)score);
            PlayerPrefs.SetInt("Highscore4", highscores[2]);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore4", 0))
        {
            PlayerPrefs.SetInt("Highscore4", (int)score);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore5", 0))
        {
            PlayerPrefs.SetInt("Highscore5", (int)score);
        }

        PlayerPrefs.SetInt("Score", (int)score);
        Debug.Log(score);
        // Send score to try again screen

    }

    public void EndGame(Scene current, Scene next)
    {
        gameEnded = true;
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", (int)score);
            PlayerPrefs.SetInt("Highscore2", highscores[0]);
            PlayerPrefs.SetInt("Highscore3", highscores[1]);
            PlayerPrefs.SetInt("Highscore4", highscores[2]);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        } else if(score > PlayerPrefs.GetInt("Highscore2", 0))
        {
            PlayerPrefs.SetInt("Highscore2", (int)score);
            PlayerPrefs.SetInt("Highscore3", highscores[1]);
            PlayerPrefs.SetInt("Highscore4", highscores[2]);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore3", 0))
        {
            PlayerPrefs.SetInt("Highscore3", (int)score);
            PlayerPrefs.SetInt("Highscore4", highscores[2]);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore4", 0))
        {
            PlayerPrefs.SetInt("Highscore4", (int)score);
            PlayerPrefs.SetInt("Highscore5", highscores[3]);
        }
        else if (score > PlayerPrefs.GetInt("Highscore5", 0))
        {
            PlayerPrefs.SetInt("Highscore5", (int)score);
        }

        PlayerPrefs.SetInt("Score", (int)score);
        Debug.Log(score);
        // Send score to try again screen

    }

}
