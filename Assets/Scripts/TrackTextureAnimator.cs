using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTextureAnimator : MonoBehaviour
{
    public float speedY;
    [SerializeField] private float currentYPos;
    [SerializeField] private float currentXPos;

    private Renderer trackRenderer;

    private void Start()
    {
        trackRenderer = GetComponent<Renderer>();
        currentYPos = trackRenderer.material.mainTextureOffset.y;
        currentXPos = trackRenderer.material.mainTextureOffset.x;
    }

    private void FixedUpdate()
    {
        currentYPos += Time.deltaTime * speedY;
        trackRenderer.material.SetTextureOffset("_MainTex", new Vector2(currentXPos, currentYPos));
    }
}
