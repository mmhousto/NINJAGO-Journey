using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.LEGO.Game;

    public class GameManager : MonoBehaviour
    {
        private GameManager _instance;

        public GameManager Instacne { get { return _instance; } }

        private Vector3 startPos;
        private Vector3 startRot;
        private int selectedChar;

        public GameObject[] playerPrefabs;

        public CinemachineVirtualCamera cam;

        public TextMeshProUGUI scoreText;

        private GameObject player;

        private float score = 0;

        private bool gameStarted = false;

        private bool gameEnded = false;

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }

            startPos = new Vector3(217.8066f, 1.4f, 268.3027f);
            startRot = new Vector3(0, 180f, 0);
            selectedChar = Random.Range(0, 9);
            player = Instantiate(playerPrefabs[selectedChar], startPos, Quaternion.Euler(startRot));
            cam.Follow = player.transform;
            cam.LookAt = player.transform;



        }

        private void Start()
        {
            Time.timeScale = 0;

        }

        public void StartGame()
        {
            Time.timeScale = 1;
            gameStarted = true;
            
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
            }

        }

        public void EndGame()
        {
            gameEnded = true;
            if(score > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", (int)score);
            }
            Debug.Log(score);
            
            // Send score to try again screen
            
        }

    }
