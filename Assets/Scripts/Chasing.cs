using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using UnityEngine.AI;

public class ChasingState : State
{
    public ChasingState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        //Debug.Log("checking for run");

        base.LogicUpdate();
        enemy.CheckForPatrol();
        GoToNextPoint();

    }
    public void GoToNextPoint()
    {
        // changes the active point to the player
        if (enemy.points.Length == 0)
        {
            return;
        }
        enemy.nav.destination = enemy.player.position;

    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
            
    }
        
}

