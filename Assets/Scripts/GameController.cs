﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// とりあえずの進行管理
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Canvas _title;
    static GameController _instance = null;
    static public GameController Instance => _instance;

    public enum GameState
    {
        InGame,
        Result
    }
    GameState _state = GameState.Result;

    static public GameState State => _instance._state;
    static public bool IsGameOver => State == GameState.Result;

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (!IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    public void GameOver(int loser)
    {
        if (loser == 1)
        {
            _text.text = "PLAYER 2 WIN";
        }

        if (loser == 2)
        {
            _text.text = "PLAYER 1 WIN";
        }

        _text.enabled = true;
        _state = GameState.Result;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameStart()
    {
        _state = GameState.InGame;
        _title.enabled = false;
    }
}
