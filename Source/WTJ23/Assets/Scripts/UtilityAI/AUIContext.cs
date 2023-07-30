using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using Apex.Serialization;


public sealed class CattleEat : ActionBase{
    public override void Execute(IAIContext context){
        var cattle = (CattleContext) context;
        cattle.actor.animator.SetTrigger("Eat");
    }
}

public sealed class MoveAround : ActionBase{
    [ApexSerialization, FriendlyName("Run?")]
    public bool Run=false;
    public override void Execute(IAIContext context){
        var cattle = (CattleContext) context;
        if(Run) cattle.actor.RunAround();
    }
}