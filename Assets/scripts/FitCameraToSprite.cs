using UnityEngine;

public class FitCameraToShopFull : MonoBehaviour
{
    public SpriteRenderer shopSprite;

    void Start()
    {
        if (shopSprite == null)
        {
            Debug.LogError("Shop Sprite is not assigned!");
            return;
        }

        Camera cam = Camera.main;

        // Set background color to black
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = Color.black;

        // Get the bounds of the sprite
        Bounds spriteBounds = shopSprite.bounds;

        float spriteWidth = spriteBounds.size.x;
        float spriteHeight = spriteBounds.size.y;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = spriteWidth / spriteHeight;

        if (screenRatio >= targetRatio)
        {
            // Wider screen: fit height
            cam.orthographicSize = spriteHeight / 2f;
        }
        else
        {
            // Taller screen: fit width
            float orthographicSize = (spriteWidth / screenRatio) / 2f;
            cam.orthographicSize = orthographicSize;
        }

        // Optional: move the camera to center on the sprite
        cam.transform.position = new Vector3(spriteBounds.center.x, spriteBounds.center.y, cam.transform.position.z);
    }
}
