using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light controlLight;

    private void OnTriggerEnter(Collider other)
    {
        controlLight.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        controlLight.gameObject.SetActive(false);
    }

}
