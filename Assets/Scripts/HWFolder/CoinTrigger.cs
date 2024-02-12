using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public ParticleSystem coinParticle;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        coinParticle.transform.position = other.transform.position;
        coinParticle.Play();
        gameObject.SetActive(false);
    }
}
