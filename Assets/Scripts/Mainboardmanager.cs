using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mainboardmanager : MonoBehaviour
{
    [SerializeField] public TMP_Text startBtn = null;

    private void Start()
    {
        startBtn.text = "Start";
    }

    public void onClickStartBtn()
    {
        startBtn.text = "Starting";
        SceneManager.LoadScene("LevelScene");
    }

    public void onClickExitBtn()
    {
        Application.Quit();
    }
}
