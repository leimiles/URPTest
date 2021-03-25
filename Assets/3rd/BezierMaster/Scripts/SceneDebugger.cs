using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.XRenderPipeline;
using UnityEngine.UI;

public class SceneDebugger : MonoBehaviour {
    private static bool lightOn;
    private OverrideCameraSettings cameraSettings;

    public Volume volume;
    private List<VolumeComponent> volumeComponents;

    public Button[] buttons;
    public Slider[] sliders;
    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 120;
        dir_Lights = Light.GetLights(LightType.Directional, 0);
        spot_Lights = Light.GetLights(LightType.Spot, 0);
        point_Lights = Light.GetLights(LightType.Point, 0);

        xrpAssets = XRenderPipeline.PipelineAsset;
        lightOn = true;
        //cameraSettings = xrpAssets.overrideCameraSettings;
        InitPost();
        InitVisualUI();
    }

    private void InitVisualUI() {
        sliders[0].value = xrpAssets.shadowDistance;
        SetButtonColor(0, lightOn);
        SetButtonColor(2, xrpAssets.useHDR);
        SetButtonColor(9, xrpAssets.supportSoftShadow);
        SetButtonColor(3, xrpAssets.supportMainLightShadow);
        SetButtonColor(15, xrpAssets.requireDepthTexture);
        SetButtonColor(16, xrpAssets.requireOpaqueTexture);
        SetButtonColor(10, xrpAssets.useClusterLighting);
        switch(xrpAssets.shadowmapResolution) {
            case ShadowmapResolution._256:
                SetButtonColor(4, true);
                SetButtonColor(5, false);
                SetButtonColor(6, false);
                SetButtonColor(7, false);
                SetButtonColor(8, false);
                break;
            case ShadowmapResolution._512:
                SetButtonColor(4, false);
                SetButtonColor(5, true);
                SetButtonColor(6, false);
                SetButtonColor(7, false);
                SetButtonColor(8, false);
                break;
            case ShadowmapResolution._1024:
                SetButtonColor(4, false);
                SetButtonColor(5, false);
                SetButtonColor(6, true);
                SetButtonColor(7, false);
                SetButtonColor(8, false);
                break;
            case ShadowmapResolution._2048:
                SetButtonColor(4, false);
                SetButtonColor(5, false);
                SetButtonColor(6, false);
                SetButtonColor(7, true);
                SetButtonColor(8, false);
                break;
            case ShadowmapResolution._4096:
                SetButtonColor(4, false);
                SetButtonColor(5, false);
                SetButtonColor(6, false);
                SetButtonColor(7, false);
                SetButtonColor(8, true);
                break;
            default:
                break;
        }
        switch(xrpAssets.msaaQuality) {
            case MSAAQuality.Disabled:
                SetButtonColor(11, true);
                SetButtonColor(12, false);
                SetButtonColor(13, false);
                SetButtonColor(14, false);
                break;
            case MSAAQuality.MSAA2x:
                SetButtonColor(11, false);
                SetButtonColor(12, true);
                SetButtonColor(13, false);
                SetButtonColor(14, false);
                break;
            case MSAAQuality.MSAA4x:
                SetButtonColor(11, false);
                SetButtonColor(12, false);
                SetButtonColor(13, true);
                SetButtonColor(14, false);
                break;
            case MSAAQuality.MSAA8x:
                SetButtonColor(11, false);
                SetButtonColor(12, false);
                SetButtonColor(13, false);
                SetButtonColor(14, true);
                break;
            default:
                break;

        }
        
    }

    // Update is called once per frame
    void Update() {

    }

    private void InitPost() {
        if(volume != null) {
            if(volume.profile != null) {
                volumeComponents = volume.profile.components;
            }
        }
    }

    public void TurnOffBloom() {
        if(volumeComponents == null) {
            return;
        }
        foreach(VolumeComponent vc in volumeComponents) {
            if(vc.name.StartsWith("Bloom")) {
                if(vc.active) {
                    vc.active = false;
                } else {
                    vc.active = true;
                }
            }
        }
    }

    public void TurnOffToneMapping() {
        if(volumeComponents == null) {
            return;
        }
        foreach(VolumeComponent vc in volumeComponents) {
            if(vc.name.StartsWith("Tonemapping")) {
                if(vc.active) {
                    vc.active = false;
                } else {
                    vc.active = true;
                }
            }
        }
    }

    public void TurnOffColorLookup() {
        if(volumeComponents == null) {
            return;
        }
        foreach(VolumeComponent vc in volumeComponents) {
            if(vc.name.StartsWith("ColorLookup")) {
                if(vc.active) {
                    vc.active = false;
                } else {
                    vc.active = true;
                }
            }
        }
    }

    public void TurnOffColorAdjustments() {
        if(volumeComponents == null) {
            return;
        }
        foreach(VolumeComponent vc in volumeComponents) {
            if(vc.name.StartsWith("ColorAdjustments")) {
                if(vc.active) {
                    vc.active = false;
                } else {
                    vc.active = true;
                }
            }
        }
    }

    public void TurnOffSoftShadow() {
        if(xrpAssets.supportSoftShadow) {
            xrpAssets.supportSoftShadow = false;
            SetButtonColor(9, false);
        } else {
            xrpAssets.supportSoftShadow = true;
            SetButtonColor(9, true);
        }
    }

    public void ChangeShadowDist() {
        xrpAssets.shadowDistance = sliders[0].value;
    }

    public static bool IsLightOn() {
        return lightOn;
    }

    public void TurnOffDepthTex() {
        if(xrpAssets.requireDepthTexture) {
            xrpAssets.requireDepthTexture = false;
            SetButtonColor(15, false);
        } else {
            xrpAssets.requireDepthTexture = true;
            SetButtonColor(15, true);
        }
    }

    public void TurnOffOverrideCam() {
        if(cameraSettings.enabled) {
            cameraSettings.enabled = false;
        } else {
            cameraSettings.enabled = true;
        }
    }

    public void TurnOffCluster() {
        if(xrpAssets.useClusterLighting) {
            xrpAssets.useClusterLighting = false;
            SetButtonColor(10, false);
        } else {
            xrpAssets.useClusterLighting = true;
            SetButtonColor(10, true);
        }
    }

    public void TurnOffOpaqueTexture() {
        if(xrpAssets.requireOpaqueTexture) {
            xrpAssets.requireOpaqueTexture = false;
            SetButtonColor(16, false);
        } else {
            xrpAssets.requireOpaqueTexture = true;
            SetButtonColor(16, true);
        }
    }

    XRenderPipelineAsset xrpAssets;
    public void TurnOffPostEffects() {
        if(xrpAssets.usePostProcess) {
            xrpAssets.usePostProcess = false;
            SetButtonColor(1, false);
        } else {
            xrpAssets.usePostProcess = true;
            SetButtonColor(1, true);
        }
    }

    public void TurnOffHDR() {
        if(xrpAssets.useHDR) {
            xrpAssets.useHDR = false;
            SetButtonColor(2, false);
        } else {
            xrpAssets.useHDR = true;
            SetButtonColor(2, true);
        }
    }

    public void TurnOffShadow() {
        if(xrpAssets.supportMainLightShadow) {
            xrpAssets.supportMainLightShadow = false;
            SetButtonColor(3, false);
        } else {
            xrpAssets.supportMainLightShadow = true;
            SetButtonColor(3, true);
        }
    }

    public void TurnOffMSAA() {
        xrpAssets.msaaQuality = MSAAQuality.Disabled;
        SetButtonColor(11, true);
        SetButtonColor(12, false);
        SetButtonColor(13, false);
        SetButtonColor(14, false);

    }

    public void SetMSAAX2() {
        xrpAssets.msaaQuality = MSAAQuality.MSAA2x;
        SetButtonColor(11, false);
        SetButtonColor(12, true);
        SetButtonColor(13, false);
        SetButtonColor(14, false);
    }

    public void SetMSAAX4() {
        xrpAssets.msaaQuality = MSAAQuality.MSAA4x;
        SetButtonColor(11, false);
        SetButtonColor(12, false);
        SetButtonColor(13, true);
        SetButtonColor(14, false);
    }

    public void SetMSAAX8() {
        xrpAssets.msaaQuality = MSAAQuality.MSAA8x;
        SetButtonColor(11, false);
        SetButtonColor(12, false);
        SetButtonColor(13, false);
        SetButtonColor(14, true);
    }

    public void TurnOffPBRMaterial() {
        if(!xrpAssets.enablePipelineDebug) {
            xrpAssets.enablePipelineDebug = true;
            xrpAssets.materialDebugMode = MaterialDebugMode.BaseColor;
        } else {
            xrpAssets.materialDebugMode = MaterialDebugMode.None;
            xrpAssets.enablePipelineDebug = false;
        }
    }

    public void TurnOffParticles() {
    }

    public void SetShadowRes256() {
        xrpAssets.shadowmapResolution = ShadowmapResolution._256;
        SetButtonColor(4, true);
        SetButtonColor(5, false);
        SetButtonColor(6, false);
        SetButtonColor(7, false);
        SetButtonColor(8, false);

    }

    public void SetShadowRes512() {
        xrpAssets.shadowmapResolution = ShadowmapResolution._512;
        SetButtonColor(4, false);
        SetButtonColor(5, true);
        SetButtonColor(6, false);
        SetButtonColor(7, false);
        SetButtonColor(8, false);
    }

    public void SetShadowRes1024() {
        xrpAssets.shadowmapResolution = ShadowmapResolution._1024;
        SetButtonColor(4, false);
        SetButtonColor(5, false);
        SetButtonColor(6, true);
        SetButtonColor(7, false);
        SetButtonColor(8, false);
    }

    public void SetShadowRes2048() {
        xrpAssets.shadowmapResolution = ShadowmapResolution._2048;
        SetButtonColor(4, false);
        SetButtonColor(5, false);
        SetButtonColor(6, false);
        SetButtonColor(7, true);
        SetButtonColor(8, false);
    }

    public void SetShadowRes4096() {
        xrpAssets.shadowmapResolution = ShadowmapResolution._4096;
        SetButtonColor(4, false);
        SetButtonColor(5, false);
        SetButtonColor(6, false);
        SetButtonColor(7, false);
        SetButtonColor(8, true);
    }

    Light[] dir_Lights;
    Light[] spot_Lights;
    Light[] point_Lights;
    public void TurnOffLight() {
        if(lightOn) {
            foreach(Light light in dir_Lights) {
                light.enabled = false;
            }
            foreach(Light light in spot_Lights) {
                light.enabled = false;
            }
            foreach(Light light in point_Lights) {
                light.enabled = false;
            }
            lightOn = false;
            //buttons[0].image.color = Color.gray;
            SetButtonColor(0, false);
        } else {
            foreach(Light light in dir_Lights) {
                light.enabled = true;
            }
            foreach(Light light in spot_Lights) {
                light.enabled = true;
            }
            foreach(Light light in point_Lights) {
                light.enabled = true;
            }
            lightOn = true;
            //buttons[0].image.color = Color.white;
            SetButtonColor(0, true);
        }

    }


    private void SetButtonColor(int index, bool isOn) {
        if(index > buttons.Length - 1) {
            return;
        }
        if(isOn) {
            buttons[index].image.color = Color.white;
        } else {
            buttons[index].image.color = Color.gray;
        }

    }
}
