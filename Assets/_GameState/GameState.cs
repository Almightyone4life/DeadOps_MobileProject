using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public float StateDuration { get; private set; } = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // for Physics

    public virtual void FixedTick()
    {

    }
    
    // for Update
    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }

    // run once when the state is entered
    public virtual void Enter()
    {
        StateDuration = 0;
    }

    // run once when state is exited
    public virtual void Exit()
    {
        
    }
}
