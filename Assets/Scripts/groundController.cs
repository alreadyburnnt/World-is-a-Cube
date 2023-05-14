using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundController : MonoBehaviour
{
    Animator anim;
    int coorX, coorY;

    void Start(){
        anim = GetComponent<Animator>();
    }

    public void setCoor(int num1, int num2){
        coorX = num1;
        coorY = num2;
    }

    public void rotate(int XY, int PN, int num){
        if(XY == 0){
            if(coorX == num){
                if(PN == 0) anim.SetTrigger("Xp");
                else if(PN == 1) anim.SetTrigger("Xn");
            }
        } else if(XY == 1){
            if(coorY == num){
                if(PN == 0) anim.SetTrigger("Yp");
                else if(PN == 1) anim.SetTrigger("Yn");
            }
        }
    }
}