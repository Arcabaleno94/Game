using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text TextcurrentLevel;
    public Text TextnextLevel;

    public LevelController Game;

    private void Start()
    {
        TextcurrentLevel.text = LevelController.instance.LevelIndex.ToString();
        TextnextLevel.text = (LevelController.instance.LevelIndex +1) .ToString();
    }
}
