using UnityEngine;

public class GameSetupState : GameState
{
    private GameFSM _stateMachine;
    private GameController _controller;

    // this our 'constructor' for the state, we pass in the state machine and controller so we can access them later
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters so we can use them later
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: SETUP");
        Debug.Log("Load save data");
        Debug.Log("Spawn Units");
       _controller.UnitSpawner.Spawn(_controller.PlayerUnitPrefab,
            _controller.PlayerUnitSpawnLocation);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
         _stateMachine.ChangeState(_stateMachine.PlayState);
    }
}
