using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_script : MonoBehaviour {
    public float time_between = 1000f;
    public int init_wait = 4;
    public float time_decrease_factor = 0.9f;
    public float Z_value = 20f;
    public float X_range = 20f;
    public float Y_range = 20f;
    public int notes = 4;
    public GameObject note;
    public int updates = 0;
    private float initial_time = 0;
    private float last_spawn = 0;
	// Use this for initialization
	void Start () {
        // Need to do nothing for 4 seconds.
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void FixedUpdate()
    {
        float current_time = Time.time;
        if (current_time - initial_time > init_wait && (current_time - last_spawn) > time_between)
        {
            last_spawn = current_time;
            spawn_notes_group();
        }
    }
    void spawn_notes_group() 
    {
        Vector3 pos = this.transform.position;
        Random.Range(-1f, 1f);
        pos.z = Z_value;
        make_note(pos);
        for (int i = 0; i < notes; i++)
        {
            Vector3 new_pos = pos;
            new_pos.x += Random.Range(-1f, 1f) * X_range;
            new_pos.y += Random.Range(-1f, 1f) * Y_range;
            make_note(new_pos);
        }
    }
    public void speed_up()
    {
        time_between *= time_decrease_factor;
        updates += 1;
    }
    private void make_note(Vector3 pos)
    {
        GameObject n = Instantiate(note) as GameObject;
        n.transform.position = pos;
    }
}
