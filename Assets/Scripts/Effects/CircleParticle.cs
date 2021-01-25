using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleParticle : MonoBehaviour
{

    [SerializeField] private float duration = 1;
    [SerializeField] private float scale = 1;
    
    float currentTime = 0.0f;
    Vector3 originalScale;
    Vector3 destinationScale;
    Material material;

    public void Start()
    {
        currentTime = 0;
        originalScale = transform.localScale;
        destinationScale = originalScale * scale;
        material = GetComponent<MeshRenderer>().material;
    }

    public void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= duration)
        {
            Destroy(gameObject);
        } else
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / duration);
            
            //float opacity = 1 - (currentTime / duration);
            //material.color = new Color(material.color.r, material.color.g, material.color.b, opacity);
        }
    }
}
