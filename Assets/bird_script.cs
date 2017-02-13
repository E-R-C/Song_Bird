using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bird_script : MonoBehaviour {
    public float Z_value = 0f;
    public Text livesT;
    public int invicible_time = 3;
    private float last_hit = 0;
    private Component Halo;
    // Use this for initialization
    void Start () {
        GameObject livesGO = GameObject.Find("Lives");
        livesT = livesGO.GetComponent<Text>();
        Halo = GetComponent("Halo");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousepos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousepos3D.x;
        pos.y = mousepos3D.y;
        pos.z = Z_value;
        this.transform.position = pos;
        // If it is not invicible
        if ((Time.time - last_hit) > invicible_time)
        {
            
            Halo.GetType().GetProperty("enabled").SetValue(Halo, false, null);
        } else
        {
            Halo.GetType().GetProperty("enabled").SetValue(Halo, true, null);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Note" && (Time.time - last_hit) > invicible_time)
        {
            last_hit = Time.time;
            Destroy(collidedWith);
            int lives = int.Parse(livesT.text);
            lives -= 1;
            livesT.text = lives.ToString();
            if (lives <= -1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
