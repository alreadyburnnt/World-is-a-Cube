using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    public GameObject[] ground = new GameObject[2];
    int[,,] groundType = new int[6, 7, 7];
    Vector3[] planePosOffset = new Vector3[6]{ new Vector3(0, 6, 0), new Vector3(6, 0, 0), new Vector3(0, 0, 6), new Vector3(-6, 0, 0), new Vector3(0, 0, -6), new Vector3(0, -6, 0) };
    Vector3[] planeRotOffset = new Vector3[6]{ new Vector3(-90, 0, 0), new Vector3(0, 90, 0), new Vector3(0, 0, 0), new Vector3(0, -90, 0), new Vector3(0, 180, 0), new Vector3(90, 0, 0) };
    Vector3[,] planeGenOffset = new Vector3[2, 6]{ { new Vector3(-1, 0, 0), new Vector3(0, 0, -1), new Vector3(0, -1, 0), new Vector3(0, 0, -1), new Vector3(0, -1, 0), new Vector3(0, 0, -1) }, 
    { new Vector3(0, 0, -1), new Vector3(0, -1, 0), new Vector3(-1, 0, 0), new Vector3(0, -1, 0), new Vector3(-1, 0, 0), new Vector3(-1, 0, 0) } };

    public GameObject[] planeController = new GameObject[6];

    void Awake()
    {
        for(int i=0;i<6;i++){
            for(int j=0;j<7;j++){
                for(int k=0;k<7;k++){
                    int temp = Random.value > 0.6 ? 0 : 1;
                    groundType[i, j, k] = temp;
                }
            }
            int[,] tempGround = new int[7, 7];
            System.Buffer.BlockCopy(groundType, 49*i*sizeof(int), tempGround, 0, 49*sizeof(int));
            planeController[i].GetComponent<planeController>().setVar(planePosOffset[i], planeRotOffset[i], planeGenOffset[0, i], planeGenOffset[1, i], ground, tempGround);
        }
    }

    void Start(){
        StartCoroutine(mainPlaneGen());
    }

    IEnumerator mainPlaneGen(){
        yield return new WaitForSeconds(1.0f);
        for(int i=0;i<6;i++){
            if(i==3) yield return new WaitForSeconds(2.0f);
            planeController[i].GetComponent<planeController>().planeGen();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
