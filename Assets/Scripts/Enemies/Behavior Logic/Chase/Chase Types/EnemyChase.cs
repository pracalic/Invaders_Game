using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase", menuName = "Enemy Logic/Chase Logic/Base Chase")]
public class EnemyChase : EnemyChaseSOBase
{
    public override void DoEnterLogic(){}
    public override void DoExitLogic(){}
    public override void DoFrameUpdateLogic(){
    //* Change States to either Idle or find resource.
        /*
            Run from the player to either get healing or to a safe distance
        */
    }
    public override void DoPhysicsLogic(){}
    public override void DoAnimationTriggerLogic(Enemy.AnimationTriggerType triggerType){}
    public override void ResetValues(){}
}