using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public Dropdown sceneListDropdown;
    // Start is called before the first frame update
    private int sceneCount;
    private List<Dropdown.OptionData> options;
    void Start() {
        //SceneManager.GetSceneByBuildIndex
        sceneCount = SceneManager.sceneCountInBuildSettings;
        if(sceneListDropdown != null) {
            sceneListDropdown.ClearOptions();
            if(sceneCount > 1) {
                options = new List<Dropdown.OptionData>();
                for(int i = 0; i < sceneCount; i++) {
                    Dropdown.OptionData option = new Dropdown.OptionData();
                    option.text = "Scene : " + i.ToString();
                    options.Add(option);
                }
                sceneListDropdown.AddOptions(options);
            }
        }
    }

    public void SwitchToScene() {
        if(sceneListDropdown == null) {
            return;
        }
        int sceneIndex = sceneListDropdown.value;
        SceneManager.LoadScene(sceneIndex);
     

    }

    // Update is called once per frame
    void Update() {

    }
}
