using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class BoundsSpawner{
    public Collider bounds;
    [Range(15,200)]
    public int MaxSpawns=50;
    public float SpawnHeight=100;
    public List<GameObject> spawnables;
}

public class GameSession : MonoBehaviour
{
    public int Timer = 720; //12 Minutes
    public List<BoundsSpawner> SpawnAreas;
    private TMPro.TextMeshProUGUI TimerText;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        TimerText = GetComponentInChildren<TMPro.TextMeshProUGUI>();

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
        yield return new WaitForEndOfFrame();
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown(){
        while(Timer>-1){
            yield return new WaitForSeconds(1);
            Timer--;
            TimerText.text = "Time " + ConvertSecondsToHHMMSS(Timer);
        }
        print("Game Over!!");
    }

    public string ConvertSecondsToHHMMSS(float secs)
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(secs);
        string result = string.Format("{1:D2}:{2:D2}",
            t.Hours,
            t.Minutes,
            t.Seconds,
            t.Milliseconds);
        return result;
    }
}
