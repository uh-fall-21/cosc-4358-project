using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    protected D_StunState stateData;

    public StunState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData): base(etity, stateMachine, animBoolName){
        this.stateData=stateData;
    }

    public override void DoChecks(){
        base.DoChecks();
    }
    public override void Enter(){
        base.Enter();
    }
    public override void Exit(){
        base.Exit();
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
    }
    
}
