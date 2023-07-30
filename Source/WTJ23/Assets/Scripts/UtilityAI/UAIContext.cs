using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using Apex.Serialization;


public class CattleContext : IAIContext
{
    public CattleContext(CattleAI actor){ this.actor = actor; }
    public CattleAI actor {get;set;}
}


public class JibaroChupaContext : IAIContext
{
    public Transform lastVictimSeen, nearestPrey;
    public JibaroChupaContext(JibCCAI actor){ this.actor = actor; }
    public JibCCAI actor {get;set;}
}

