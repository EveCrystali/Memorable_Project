using UnityEngine;
using System.Collections.Generic;

public class RandomLayer : MonoBehaviour
{
    public string[] possibleLayers = { "Vision_01", "Vision_02" , "Invisible" };
    private List<string> availableLayers = new List<string>();

    void Awake()
    {
        availableLayers.AddRange(possibleLayers);

        foreach (Transform child in transform)
        {
            if (availableLayers.Count == 0)
            {
                Debug.LogWarning("No more available layers to assign.");
                return;
            }

            int randomIndex = Random.Range(0, availableLayers.Count);
            string selectedLayer = availableLayers[randomIndex];
            availableLayers.RemoveAt(randomIndex);

            int layerIndex = LayerMask.NameToLayer(selectedLayer);
            if (layerIndex == -1)
            {
                layerIndex = LayerMask.NameToLayer(selectedLayer);
                Debug.LogWarning("Layer " + selectedLayer + " not found. Creating a new layer with this name.");
            }

            child.gameObject.layer = layerIndex;
            SetChildrenLayer(child, layerIndex);
        }
    }

    void SetChildrenLayer(Transform parent, int layerIndex)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.layer = layerIndex;
            SetChildrenLayer(child, layerIndex);
        }
    }
}
