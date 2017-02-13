using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Note_script : MonoBehaviour {
    public float speed = 1f;
    public float minX, minY= 0f;
    public float maxX = 20f;
    public float maxY = 20f;
    public Text scoreGT;
    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0f, 0f, -9.81f);
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 t = this.transform.position;
        if (t.z < 0 || t.x < minX || t.x > maxX || t.y > maxY || t.y < minY)
        {
            Destroy(this.gameObject);
            int score = int.Parse(scoreGT.text);
            score += 1;
            scoreGT.text = score.ToString();
        }
        
    }
}
