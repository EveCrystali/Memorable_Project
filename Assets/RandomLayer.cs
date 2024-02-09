using UnityEngine;

public class RandomLayer : MonoBehaviour
{
    public string[] possibleLayers = { "Vision_01", "Vision_02" };

    void Start()
    {
        foreach (Transform child in transform)
        {
            int randomIndex = Random.Range(0, possibleLayers.Length);
            string selectedLayer = possibleLayers[randomIndex];

            int layerIndex = LayerMask.NameToLayer(selectedLayer);
            if (layerIndex == -1)
            {
                layerIndex = LayerMask.NameToLayer(selectedLayer);
                Debug.LogWarning("Layer " + selectedLayer + " not found. Creating a new layer with this name.");
            }

            child.gameObject.layer = layerIndex;
        }
    }
}
