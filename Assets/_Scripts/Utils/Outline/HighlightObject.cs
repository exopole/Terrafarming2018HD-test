﻿using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class HighlightObject : MonoBehaviour
{
    public float animationTime = 1f;
    public float threshold = 1.5f;

    private HighlightController controller;
    private Material material;
    public Color normalColor;
    private Color selectedColor;

    private void Awake()
    {
        material = GetComponent<SkinnedMeshRenderer>().material;
        controller = FindObjectOfType<HighlightController>();

        //normalColor = material.color;
        selectedColor = new Color(
          Mathf.Clamp01(normalColor.r * threshold),
          Mathf.Clamp01(normalColor.g * threshold),
          Mathf.Clamp01(normalColor.b * threshold)
        );
    }

    private void Start()
    {
        StartHighlight();
    }

    public void StartHighlight()
    {
        iTween.ColorTo(gameObject, iTween.Hash(
          "color", selectedColor,
          "time", animationTime,
          "easetype", iTween.EaseType.linear,
          "looptype", iTween.LoopType.pingPong
        ));
    }

    public void StopHighlight()
    {
        iTween.Stop(gameObject);
        material.color = normalColor;
    }

    private void OnMouseDown()
    {
        controller.SelectObject(this);
    }
}