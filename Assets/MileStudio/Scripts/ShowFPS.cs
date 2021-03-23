using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour {

    public float timer, refresh, avgFramerate;
    public string info;
    // Start is called before the first frame update
    public Text text;
    /*
    private void OnGUI() {
        GUILayout.TextArea(info);
    }
    */
    private void Start() {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        float timelapse = Time.deltaTime;
        timer = timer <= 0 ? refresh : timer - timelapse;
        if(timer <= 0) {
            avgFramerate = (int)(1.0f / timelapse);
            //info = avgFramerate.ToString();
            if(text != null) {
                text.text = avgFramerate.ToString();
            }
        }
    }
}
