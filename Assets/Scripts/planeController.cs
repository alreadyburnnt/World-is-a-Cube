using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeController : MonoBehaviour
{
    public GameObject planeParent;
    public GameObject planeSelf;
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

    public void fixCoor(){
        for(int i=0;i<49;i++){
            this.transform.GetChild(i).GetChild(0).position += this.transform.GetChild(i).position;
            this.transform.GetChild(i).position = new Vector3(0, 0, 0);
        }
    }

    public void rotate(int XY, int PN, int num){
        for(int i=0;i<49;i++){
            transform.GetChild(i).gameObject.GetComponent<groundController>().rotate(XY, PN, num);
        }
    }

    IEnumerator planeGenEnum(){
        int cnt = 0;
        for(int i=0;i<=12;i++){
            for(int j=0;j<7;j++){
                if(i-j>6 || j>6 || i-j<0 || j<0) continue;
                Instantiate(ground[groundType[j, i-j]], planePosOffset + planeGenOffset[0]*(j*2-6) + planeGenOffset[1]*((i-j)*2-6), planeQuat, planeParent.transform);
                planeSelf.transform.GetChild(cnt++).gameObject.GetComponent<groundController>().setCoor(j, i-j);
                yield return new WaitForSeconds(0.05f);
            }
        }
        fixCoor();
    }
}