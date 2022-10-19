using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :MonoBehaviour
{
    public static GameManager Instance;
    public GameObject StartP, InGameP, NextP, GameOverP;
    public float countdown = 2.0f;
    [SerializeField] private int asynSceneIndex = 1;


    private void Awake()
    {
        if(Instance==null) { Instance = this; }
        DontDestroyOnLoad(this);
    }
    public enum GameState // we arrange state and panels
    {
        Start,
        InGame,
        Next,
        GameOver
    }
    public GameState gamestate; //get reference
    public enum Panels
    {
        Startp,
        Nextp,
        GameOverp,
        InGamep
    }

    private void Start()
    {
        gamestate = GameState.Start;
   

    }
    public void Update()
    {
        switch (gamestate)
        {
            case GameState.Start:
                GameStart();
                break;
            case GameState.InGame:
                InGame();
                break;
            case GameState.Next:
                Next();
                break;
            case GameState.GameOver:
                GameOver();
                break;

        }
    }
    public void PanelController(Panels currentpanel)
    {
        StartP.SetActive(false);
        InGameP.SetActive(false);
        NextP.SetActive(false);
        GameOverP.SetActive(false);
        switch (currentpanel)
        {
            case Panels.Startp:
                StartP.SetActive(true);
                break;
            case Panels.Nextp:
                NextP.SetActive(true);
                break;
            case Panels.GameOverp:
                GameOverP.SetActive(true);
                break;
            case Panels.InGamep:
                InGameP.SetActive(true);

                break;
        }

    }
    public void GameStart()
    {
        PanelController(Panels.Startp);
        //if (Input.anyKeyDown)

    }
    public void StartClick()
    {
        gamestate = GameState.InGame;

        if (SceneManager.sceneCount < 2)
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
    }
    void InGame()
    {
        PanelController(Panels.InGamep);
        UIManager.Instance._gameUI.gameObject.SetActive(true);
        Time.timeScale = 1;

    }
    void Next()
    {
        UIManager.Instance._gameUI.gameObject.SetActive(false);
        PanelController(Panels.Nextp);
        Player3DExample.JoystickEvent?.Invoke();
        Time.timeScale = 0;
    }
    void GameOver()
    {
        UIManager.Instance._gameUI.gameObject.SetActive(false);
        Player3DExample.JoystickEvent?.Invoke();
        countdown -= Time.deltaTime;
        if (countdown < 0)
        {
            PanelController(Panels.GameOverp);
            countdown = 2.5f;
            Time.timeScale = 0;
        }

    }
    public void RestartButton()
    {

        SceneManager.UnloadSceneAsync(asynSceneIndex);
        //SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        gamestate = GameState.Start;
    }

    public void NextLevelButton() //When the game finished, we get loop each levels to infinity
    {
        if (SceneManager.sceneCountInBuildSettings == asynSceneIndex + 1)
        {
            SceneManager.UnloadSceneAsync(asynSceneIndex);
            asynSceneIndex = 1;
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }
        else
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(asynSceneIndex);
                asynSceneIndex++;
            }
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }
        gamestate = GameState.InGame;
    }
}
