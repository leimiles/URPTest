using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CamAim : MonoBehaviour {
    public GameObject aimTarget;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        AimTarget();
    }

    private void AimTarget() {
        if(aimTarget == null) {
            return;
        }
        this.transform.LookAt(aimTarget.transform, Vector3.up);


    }
}
