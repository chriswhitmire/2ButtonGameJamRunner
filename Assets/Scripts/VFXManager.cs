using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public void makeEffect(ParticleSystem particle, GameObject otherGameObject)
    {
        Instantiate(particle, otherGameObject.transform);
    }
}
