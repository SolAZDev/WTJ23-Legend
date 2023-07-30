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

public sealed class CattleGoAround : ActionBase{
    [ApexSerialization, FriendlyName("Run?")]
    public bool Run=false;
    public override void Execute(IAIContext context){
        var cattle = (CattleContext) context;
        if(Run) cattle.actor.RunAround();
        else cattle.actor.MoveAround();
    }
}

public sealed class JibaroChupaGoAround : ActionBase{
    [ApexSerialization, FriendlyName("Run?")]
    public bool Run=false;
    public override void Execute(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        cattle.actor.navMeshAgent.speed = Run?cattle.actor.RunSpeed:cattle.actor.Speed;
        cattle.actor.navMeshAgent.SetDestination(cattle.actor.transform.position+Random.onUnitSphere*50);
    }
}

public sealed class JibaroChupaGoToLastThingHeard : ActionBase{
    [ApexSerialization, FriendlyName("Run?")]
    public bool Run=false;
    public override void Execute(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        cattle.actor.navMeshAgent.speed = Run?cattle.actor.RunSpeed:cattle.actor.Speed;
        cattle.actor.navMeshAgent.SetDestination(cattle.actor.lastAudioArea);
    }
}

public sealed class JibaroChupaGoToTarget : ActionBase{
     [ApexSerialization, FriendlyName("Run?")]
    public bool Run=false;
    public override void Execute(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        cattle.actor.GoToTarget(Run);
    }
}

public sealed class JibaroChupaAttack : ActionBase{
    public override void Execute(IAIContext context){
        var cattle = (JibaroChupaContext) context;

        //TODO: MOve this ot JiCAI.Attack
        cattle.actor.animator.SetTrigger("Attack1");
    }
}
