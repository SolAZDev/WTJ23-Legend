using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using Apex.Serialization;

public sealed class CattleWantsToEat: ContextualScorerBase{
    public override float Score(IAIContext context){
        var cattle = (CattleContext) context;
        return (cattle.actor.Nervouseness<.2f && Random.Range(0,10)>5)?this.score:0;
    }
}

public sealed class CattleSeesChupa: ContextualScorerBase{
    public override float Score(IAIContext context){
        var cattle = (CattleContext) context;
        var cc = GameObject.FindWithTag("Chupa").transform;
        float DetectAngle = Vector3.Angle(cattle.actor.transform.forward, cattle.actor.transform.position-cc.position);
        bool final = ((Mathf.Abs(DetectAngle) > 90 && Mathf.Abs(DetectAngle) < 270) && 
                      Vector3.Distance(cc.position, cattle.actor.transform.position) < Random.Range(15,50));
        cattle.actor.Nervouseness+=final?.07f:0;
        return final  ? this.score : 0;
    }
}

public sealed class CattleNervousBelowThreshold: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Run?")]public float Threshold;
    public override float Score(IAIContext context){
        var cattle = (CattleContext) context;
        return (cattle.actor.Nervouseness<=Threshold)?this.score:0;
    }
}

public sealed class CattleNervousAboveThreshold: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Run?")]public float Threshold;
    public override float Score(IAIContext context){
        var cattle = (CattleContext) context;
        return (cattle.actor.Nervouseness>=Threshold)?this.score:0;
    }
}

