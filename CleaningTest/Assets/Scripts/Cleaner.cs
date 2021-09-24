using UnityEngine;

namespace AbdulkadirDursun.TextureCleaning
{
    public class Cleaner : MonoBehaviour
    {
        //[SerializeField] private Texture2D brushTexture;        
        [SerializeField] private int brushSize = 5;
        private Camera cam;
        private Texture2D dirtTexture = null;

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
                if (dirtTexture == null)
                    dirtTexture = hit.collider.GetComponent<SpriteRenderer>().sprite.texture;

                int pixelPerUnit = (int)hit.collider.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
                Vector2 uvCoord = ConvertPixelToUVCoordinates(dirtTexture.width, dirtTexture.height, pixelPerUnit, pixelPerUnit);

                float heightRatio = (dirtTexture.height / (uvCoord.y * 2));
                float widthRatio = (dirtTexture.width / (uvCoord.x * 2));

                uvCoord += mousePos;
                int pixelX = (int)(uvCoord.x * widthRatio);
                int pixelY = (int)(uvCoord.y * heightRatio);
                CleanWithBrush(pixelX, pixelY);
                return;

                dirtTexture.SetPixel(pixelX, pixelY, new Color32(0, 0, 0, 0));
                dirtTexture.Apply();
            }
        }

        private void CleanWithBrush(int _pixelX, int _pixelY)
        {
            int pixelXOfSet = _pixelX - (brushSize / 2);
            int pixelYOfSet = _pixelY - (brushSize / 2);

            for (int x = 0; x < brushSize; x++)
            {
                for (int y = 0; y < brushSize; y++)
                {
                    dirtTexture.SetPixel(pixelXOfSet + x, pixelYOfSet + y, new Color(0, 0, 0, 0));
                }
            }
                    dirtTexture.Apply();
        }
        private Vector2 ConvertPixelToUVCoordinates(int x, int y, int textureWidth, int textureHeight)
        {
            return new Vector2((float)x / textureWidth, (float)y / textureHeight);
        }
    }
}