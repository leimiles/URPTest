using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Framerate : MonoBehaviour {
    private int frameCount = 0;
    private float timeCounter = 0.0f;
    private float refreshTime = 0.1f;


    [SerializeField]
    private Text framerateText;

    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update() {
        SetFrameRate();

    }

    private void SetFrameRate() {
        if(timeCounter < refreshTime) {
            timeCounter += Time.deltaTime;
            frameCount++;
        } else {
            float lastFramerate = frameCount / timeCounter;
            frameCount = 0;
            timeCounter = 0.0f;
            framerateText.text = lastFramerate.ToString("n2");
        }
    }
}
