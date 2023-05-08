using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeController : MonoBehaviour
{
    public GameObject planeParent;
    Vector3 planePosOffset;
    Vector3 planeRotOffset;
    Quaternion planeQuat;
    Vector3[] planeGenOffset = new Vector3[2];
    GameObject[] ground = new GameObject[2];
    int[,] groundType = new int[7, 7];

    public void setVar(Vector3 pPO, Vector3 pRO, Vector3 pGO1, Vector3 pGO2, GameObject[] _ground, int[,] _groundType){
        planePosOffset = pPO;
        planeRotOffset = pRO;
        planeQuat = Quaternion.Euler(planeRotOffset.x, planeRotOffset.y, planeRotOffset.z);
        planeGenOffset[0] = pGO1;
        planeGenOffset[1] = pGO2;
        ground = _ground;
        groundType = _groundType;
    }

    public void planeGen(){
        StartCoroutine(planeGenEnum());
    }

    IEnumerator planeGenEnum(){
        for(int i=0;i<=12;i++){
            for(int j=0;j<7;j++){
                if(i-j>6 || j>6 || i-j<0 || j<0) continue;
                Debug.Log("(" + i + ", " + (i-j) + ")");
                Instantiate(ground[groundType[j, i-j]], planePosOffset + planeGenOffset[0]*(j*2-6) + planeGenOffset[1]*((i-j)*2-6), planeQuat, planeParent.transform);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}