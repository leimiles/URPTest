using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetChecker : EditorWindow {
    [MenuItem("ArtTools/Assets Check/Mesh Check ")]
    public static void MeshCheckWindowInit() {
        AssetChecker assetCheckWindow = EditorWindow.GetWindow<AssetChecker>();
        assetCheckWindow.Show();
    }

    private void Update() {
        //Repaint();
    }


    private void OnGUI() {
        if(GUILayout.Button("Show All Textures ( Project )")) {
            string[] allTextures = AssetDatabase.FindAssets("t:texture2D", new[] { "Assets" });
            Debug.Log(allTextures.Length);
        }
        if(GUILayout.Button("Show All Textures ( Scene )")) {

        }

        if(GUILayout.Button("Show All Meshes ( Scene )")) {
            if(EyesOnAssets._isShowMeshes) {
                EyesOnAssets._isShowMeshes = false;
            } else {
                EyesOnAssets._isShowMeshes = true;
            }
        }

        GUILayout.BeginHorizontal();
        if(EyesOnAssets._isShowMeshes) {
            GUILayout.Label("顶点数大于: ", GUILayout.Width(70));
            GUILayout.Label(" 10 ", GUILayout.Width(20));
            EyesOnAssets._vertexLimitMax = (int)GUILayout.HorizontalSlider(EyesOnAssets._vertexLimitMax, 10, 500000, GUILayout.ExpandWidth(true));
            GUILayout.Label(EyesOnAssets._vertexLimitMax.ToString(), GUILayout.Width(50));
            if(GUILayout.Button("搜索", GUILayout.Width(120))) {
                EyesOnAssets._isShowMeshesResult = true;
            }
        }

        GUILayout.EndHorizontal();

        if(EyesOnAssets._isShowMeshes) {
            if(EyesOnAssets._isShowMeshesResult) {
                GUILayout.Label("场景中共有网格对象数量: " + EyesOnAssets.GetAllMeshesCount_Scene());
                GUILayout.Label("顶点 Top 10: ");
                for(int i = 0; i < EyesOnAssets.sortedMeshfilters.Length; i++) {
                    if(i < 10) {
                        GUILayout.Label("名称: " + EyesOnAssets.sortedMeshfilters[i].sharedMesh.name + "\t顶点数: " + EyesOnAssets.sortedMeshfilters[i].sharedMesh.vertexCount);
                    }
                }
            }
        }
    }
}
