using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAutoAdjust : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // The aspect ratio you designed for (e.g., 16:9)
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        AdjustCamera();
    }

    void AdjustCamera()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Letterbox
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            cam.rect = rect;
        }
        else
        {
            // Pillarbox
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }
    }
}
