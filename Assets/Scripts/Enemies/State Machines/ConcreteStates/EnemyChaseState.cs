using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    // If Player is in line of sight start to chase
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        // Get player if any
    }
    public override void EnterState(){
        base.EnterState();
        enemy.EnemyChaseBaseInstance.DoEnterLogic();

    }
    public override void ExitState(){
       base.ExitState();
       enemy.EnemyChaseBaseInstance.DoExitLogic();

    }
    public override void FrameUpdate(){
        base.FrameUpdate();
        enemy.EnemyChaseBaseInstance.DoFrameUpdateLogic();

    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        enemy.EnemyChaseBaseInstance.DoPhysicsLogic();

    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType){
        base.AnimationTriggerEvent(triggerType);
        enemy.EnemyChaseBaseInstance.DoAnimationTriggerLogic(triggerType);

    }
}

