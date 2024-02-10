using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationConditions : MonoBehaviour
{
    public string layerNameActivation = "Invisible";
    public GameObject gameObjectToActivate;

    void Start()
    {
        if (gameObject.layer == LayerMask.NameToLayer(layerNameActivation))
        {
            gameObjectToActivate.SetActive(true);
        }
        else
        {
            gameObjectToActivate.SetActive(false);
        }
    }
}
