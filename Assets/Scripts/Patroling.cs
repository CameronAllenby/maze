using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using System.Security.Cryptography;

public class Patroling : State
{
    // Start is called before the first frame update
    public Patroling(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
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
        base.LogicUpdate();
        enemy.CheckForChase();
        if (!enemy.nav.pathPending && enemy.nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
    void GoToNextPoint()
    {
        // changes the active point
        if (enemy.points.Length == 0)
        {
            return;
        }
        enemy.nav.destination = enemy.points[enemy.destPoint].position;
        enemy.destPoint = (enemy.destPoint + 1) % enemy.points.Length;
    }
}
