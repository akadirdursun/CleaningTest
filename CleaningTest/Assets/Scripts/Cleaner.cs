using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            Cleaning();
        }
    }

    private void Cleaning()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit)
        {            
            Texture2D texture = hit.collider.GetComponent<SpriteRenderer>().sprite.texture;
            int pixelPerUnit = (int)hit.collider.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            Vector2 uvCoord = ConvertPixelToUVCoordinates(texture.width, texture.height, pixelPerUnit, pixelPerUnit);

            float heightRatio = (texture.height / (uvCoord.y * 2));
            float widthRatio = (texture.width / (uvCoord.x * 2));

            uvCoord += mousePos;
            int pixelX = (int)(uvCoord.x * widthRatio);
            int pixelY = (int)(uvCoord.y * heightRatio);
            texture.SetPixel(pixelX, pixelY, new Color32(0, 0, 0, 0));
            texture.Apply();
        }
    }

    private Vector2 ConvertPixelToUVCoordinates(int x, int y, int textureWidth, int textureHeight)
    {
        return new Vector2((float)x / textureWidth, (float)y / textureHeight);
    }
}