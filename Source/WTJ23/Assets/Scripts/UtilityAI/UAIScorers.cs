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
    [ApexSerialization, FriendlyName("Threshold")]public float Threshold;
    public override float Score(IAIContext context){
        var cattle = (CattleContext) context;
        return (cattle.actor.Nervouseness<=Threshold)?this.score:0;
    }
}

public sealed class CattleNervousAboveThreshold: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Threshold")]public float Threshold;
    public override float Score(IAIContext context){
        var cattle = (CattleContext) context;
        return (cattle.actor.Nervouseness>=Threshold)?this.score:0;
    }
}

public sealed class JibaroChupaCanStillFight: ContextualScorerBase{
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        return cattle.actor.Health>=6  ? this.score : 0;
    }
}
public sealed class JibaroChupaCantFight: ContextualScorerBase{
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        return cattle.actor.Health<=5  ? this.score : 0;
    }
}
public sealed class JibaroChupaNerveAboveThreshold: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Threshold")]public float Threshold;
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        return (cattle.actor.Nervouseness>=Threshold)?this.score:0;
    }
}
public sealed class JibaroChupaNerveBelowThreshold: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Threshold")]public float Threshold;
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        return (cattle.actor.Nervouseness<=Threshold)?this.score:0;
    }
}
public sealed class JibaroChupaHeardSomething: ContextualScorerBase{
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        return (cattle.actor.lastAudioArea!=Vector3.zero)?this.score:0;
    }
}

public sealed class JibaroChupaCloseEnough: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Max Distance")]public float maxDist;
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        return (Vector3.Distance(cattle.actor.transform.position, cattle.actor.targetPos)<maxDist)  ? this.score : 0;
    }
}

public sealed class JibaroChupaSeesEnemy: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Are you Chupa?")]public bool isChupa;
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        var cc = GameObject.FindWithTag(isChupa?"Jibaro":"Chupa").transform;
        float DetectAngle = Vector3.Angle(cattle.actor.transform.forward, cattle.actor.transform.position-cc.position);
        bool final = ((Mathf.Abs(DetectAngle) > 90 && Mathf.Abs(DetectAngle) < 270) && 
                      Vector3.Distance(cc.position, cattle.actor.transform.position) < 50);
        if(final){
            cattle.actor.Nervouseness+=.2f;
            cattle.actor.targetPos=cc.position;
        }
        return final  ? this.score : 0;
    }
}

public sealed class JibaroChupaSeesDead: ContextualScorerBase{
    [ApexSerialization, FriendlyName("Must See within Range")]public bool onlyInViewCone;
    public override float Score(IAIContext context){
        var cattle = (JibaroChupaContext) context;
        GameObject[] corpses = GameObject.FindGameObjectsWithTag("Perished");
        GameObject fCorpse=null;
        float lastDist=1000;
        foreach(var corpse in corpses){
            float dist =Vector3.Distance(cattle.actor.transform.position,corpse.transform.position);
            if(dist<lastDist){
                fCorpse=corpse;
                lastDist=dist;
            }
        }
        if(fCorpse!=null){
            if(onlyInViewCone){
                float DetectAngle = Vector3.Angle(cattle.actor.transform.forward, cattle.actor.transform.position-fCorpse.transform.position);
                bool final = ((Mathf.Abs(DetectAngle) > 90 && Mathf.Abs(DetectAngle) < 270) && 
                      Vector3.Distance(fCorpse.transform.position, cattle.actor.transform.position) < Random.Range(15,50));
                if(final){
                    cattle.actor.Nervouseness+=.2f;
                    cattle.actor.targetPos=fCorpse.transform.position;
                    return this.score;
                }
            }else{
                cattle.actor.Nervouseness+=.2f;
                cattle.actor.targetPos=fCorpse.transform.position;
                return this.score;
            }
        }
        return 0;
    }
}