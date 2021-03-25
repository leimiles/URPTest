using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.XRenderPipeline;

[DisallowMultipleComponent]
[RequireComponent(typeof(Volume))]
public class PostSwitcher : MonoBehaviour {
    // Start is called before the first frame update
    VolumeProfile profile;
    Volume volume;
    List<VolumeComponent> components;
    void Start() {
        volume = this.GetComponent<Volume>();
        profile = volume.profile;
        if(profile != null) {
            components = profile.components;
        }
    }

    public List<VolumeComponent> GetVolumeComponents() {
        return components;
    }

    

    // Update is called once per frame
    void Update() {

    }
}
