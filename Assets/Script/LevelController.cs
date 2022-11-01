using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    private void Awake()
    {
        instance = this;
    }

    public float gameSpeed = 2;

    public int obstaclesAmount = 6;

    public float damageTime = 0.1f;

    //цвета
    public Color easyColor, mediumColor, hardColor;

    internal int obstacleAmount;

    
}
