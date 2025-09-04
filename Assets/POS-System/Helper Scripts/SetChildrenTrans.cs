#if UNITY_EDITOR 
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SetChildrenTrans : MonoBehaviour
{


    [Range(0, 1)]
    [SerializeField] private float desiredAlpha = 0f;
    RawImage[] rawImages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rawImages = GetComponentsInChildren<RawImage>();
    }

    void OnDrawGizmos()
    {
        if (rawImages == null)
        {
            return;
        }
        foreach (RawImage rawImage in rawImages)
        {
            rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, desiredAlpha);
        }
    }
}
#endif