using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsSpawner{
    public Collider bounds;
    [Range(15,200)]
    public int MaxSpawns=50;
    public float SpawnHeight=100;
    public List<GameObject> spawnables;
}

public class GameSession : MonoBehaviour
{
    public float Timer = 720; //12 Minutes
    public List<BoundsSpawner> SpawnAreas;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAreas.ForEach(area=>{
            if(area.spawnables.Count<1) return;
            for (int i = 0; i < Random.Range(15,area.MaxSpawns); i++){
                Vector3 bounds = area.bounds.bounds.extents;
                Vector3 spawnerPosition = area.bounds.transform.position;
                Vector3 itemPosition = new Vector3(
                                                    spawnerPosition.x+Random.Range(-bounds.x, bounds.x),
                                                    area.SpawnHeight,
                                                    spawnerPosition.z+Random.Range(-bounds.z, bounds.z));
                Instantiate(area.spawnables[Random.Range(0,area.spawnables.Count-1)], itemPosition, Quaternion.identity);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
