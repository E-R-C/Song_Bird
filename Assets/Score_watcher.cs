using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_watcher : MonoBehaviour {
    public Spawner_script spawn_script;
    public float time_to_faster = 10f;
    private float last_update_time = 0f;
    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        if ((Time.time - last_update_time )> time_to_faster)
        {
            last_update_time = Time.time;
            spawn_script.speed_up();
        }
    }
}
