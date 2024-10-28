using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [field: SerializeField] public float CurrentHealth { get; set; }
    [field: SerializeField] public bool IsWithinStrikingDistance { get; set; }

    #region State Machine Variables
    public EnemyStateMachine StateMachine {get; set;}
    public EnemyIdleState IdleState {get; set;}
    public EnemyAttackState AttackState {get; set;}
    public EnemyChaseState ChaseState {get; set;}
    #endregion

    #region ScriptableObject Variables
    [SerializeField] private EnemyIdleSOBase EnemyIdleBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;
    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;
    public EnemyAttackSOBase EnemyAttackBaseInstance {get; set;}
    public EnemyChaseSOBase EnemyChaseBaseInstance {get; set;}
    public EnemyIdleSOBase EnemyIdleBaseInstance {get; set;}

    #endregion

    public enum AnimationTriggerType{
        // These are examples
        EnemyDamaged,
        PlayFootstepSound,
    }


    private void Awake() {

        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);

        StateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }
    void Start()
    {
        EnemyAttackBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyIdleBaseInstance.Initialize(gameObject, this);
        StateMachine.Initialize(IdleState);
    }
    void Update(){

    }


    public void Damage(float damageAmount, Vector3 attacker){

    }
    public void Die(){

    }



}
