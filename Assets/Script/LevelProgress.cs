using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{

    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float AcceptableFinishPlayerDistance = 1f;

    private float _startY;
    private float _minimumReachedY;

    private void Start()
    {
        _startY = Player.transform.position.y;
    }

    private void Update()
    {
       float currentY = Player.transform.position.y;
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY, currentY);
        Slider.value = t;
    }

}
