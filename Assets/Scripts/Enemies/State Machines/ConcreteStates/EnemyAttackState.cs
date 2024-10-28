using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    // Start is called before the first frame update
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        // Get Player if any
    }
    public override void EnterState(){
        base.EnterState();
        enemy.EnemyAttackBaseInstance.DoEnterLogic();
    }
    public override void ExitState(){
        base.ExitState();
        enemy.EnemyAttackBaseInstance.DoExitLogic();
    }
    public override void FrameUpdate(){
        base.FrameUpdate();
        enemy.EnemyAttackBaseInstance.DoFrameUpdateLogic();
    }
    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        enemy.EnemyAttackBaseInstance.DoPhysicsLogic();
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType){
        base.AnimationTriggerEvent(triggerType);
        enemy.EnemyAttackBaseInstance.DoAnimationTriggerLogic(triggerType);
    }
}
