using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] private Sprite dirtSprite;
    private SpriteRenderer spriteRenderer;
    private Texture2D baseTexture;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseTexture = Instantiate(dirtSprite.texture);
        spriteRenderer.sprite = dirtSprite;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InstantiateNewSprite();
        }
    }

    private void OnDisable()
    {
        InstantiateNewSprite();
    }

    private void InstantiateNewSprite()
    {       
        dirtSprite.texture.SetPixels(baseTexture.GetPixels());
        dirtSprite.texture.Apply();
        spriteRenderer.sprite = dirtSprite;
    }
}
