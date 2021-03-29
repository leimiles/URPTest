using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EyesOnAssets {
    public static bool _isShowMeshes = false;
    public static bool _isShowMeshesResult = false;
    public static int _vertexLimitMax = 500;

    public static int GetAllMeshesCount_Scene() {
        MeshFilter[] mfs = GameObject.FindObjectsOfType<MeshFilter>();
        SortMeshFilters(mfs);
        return mfs.Length;
    }

    public static MeshFilter[] sortedMeshfilters;
    private static void SortMeshFilters(MeshFilter[] meshFilters) {
        MeshFilter bigOne;
        for(int i = 0; i < meshFilters.Length - 1; i++) {
            for(int j = 0; j < meshFilters.Length - 1 - i; j++) {
                if(meshFilters[j].sharedMesh.vertexCount < meshFilters[j + 1].sharedMesh.vertexCount) {
                    bigOne = meshFilters[j];
                    meshFilters[j] = meshFilters[j + 1];
                    meshFilters[j + 1] = bigOne;
                }
            }
        }
        sortedMeshfilters = meshFilters;
    }
}
