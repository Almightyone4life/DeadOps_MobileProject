using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    public GameSetupState SetupState { get; private set; }
    public GamePlayState PlayState { get; private set; }

    // state varibles here
    private void Awake()
    {
        _controller = GetComponent<GameController>();
        // state initialization here
        SetupState = new GameSetupState(this, _controller);
        PlayState = new GamePlayState(this, _controller);
    }

    private void Start()
    {
        // set the initial state here
        ChangeState(SetupState);
    }
}
