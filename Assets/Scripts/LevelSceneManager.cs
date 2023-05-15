using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    readonly int maxLevel = 7;
    public TMP_Text btntext = null;
    public int currentLevel;
        
    private void Start()
    {
        currentLevel = 1;
        btntext.text = $"Level {currentLevel}";
    }

    public void OnClickNextBtn()
    {
        if (currentLevel != maxLevel) currentLevel++;
        else currentLevel = 1;

        btntext.text = $"Level {currentLevel}";
    }

    public void OnClickPrevBtn()
    {
        if (currentLevel != 1) currentLevel--;
        else currentLevel = maxLevel;

        btntext.text = $"Level {currentLevel}";
    }

    public void OnClickLevelBtn()
    {
        LoadingSceneManager.LoadScene("GameScene");
    }

    public void OnClickBackBtn()
    {
        SceneManager.LoadScene("Mainboard");
    }
}
