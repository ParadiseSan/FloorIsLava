using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameState currentState { get; private set; }

        public enum GameState
        {
            MainMenu,
            Lobby,
            Countdown,
            Playing,
            Paused,
            GameOver,
            Loading
        }
        internal Counter CountdownCounter;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ChangeState(GameState.MainMenu);

        }

        private void Update()
        {
            Debug.Log(currentState.ToString());
        }
        public void ChangeState(GameState newState)
        {
            currentState = newState;

            switch (newState)
            {
                case GameState.MainMenu:
                    // Initialize main menu
                    break;
                case GameState.Countdown:
                    // Initialize countdown
                    StartCoroutine(CountdownCounter.StartCountdown());
                    break;
                case GameState.Playing:
                    // Initialize playing state
                    break;
                case GameState.Paused:
                    // Initialize paused state
                    break;
                case GameState.GameOver:
                    // Initialize game over state
                    break;
                case GameState.Loading:
                    break;
            case GameState.Lobby:
                break;
                default:
                    break;
            }
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        public void LoadScene(int index)
        {
            StartCoroutine(LoadSceneAsync(index));
        }
        private IEnumerator LoadSceneAsync(string sceneName)
        {
            ChangeState(GameState.Loading);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }


        }

        private IEnumerator LoadSceneAsync(int index)
        {
            ChangeState(GameState.Loading);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }


        }
        public void StartGame(int nextSceneIndex)
        {
            LoadScene(nextSceneIndex);
            //Invoke("StartCountDown", 0.5f);
            ChangeState(GameState.Lobby); // remember to add countdown state after lobby scene
        }

        void StartCountDown()
        {
            ChangeState(GameState.Countdown);
        }

        public void PauseGame()
        {
            ChangeState(GameState.Paused);
        }

        public void ResumeGame()
        {
            ChangeState(GameState.Playing);
        }

        public void EndGame()
        {
            ChangeState(GameState.GameOver);
        }
    }
