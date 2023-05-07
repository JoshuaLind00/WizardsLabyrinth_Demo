using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Light lightValue;

    public float glowRange;
    public float glowIntensity;
    private float flickerTimeI;
    public float flickerAmount = 0.2f;
    public float flickerIntensityI = 3.0f;
    public float flickerSpeedI = 0.1f;



    // Start is called before the first frame update
    private void Start()
    {
        lightValue = GetComponent<Light>();
        lightValue.type = LightType.Point;
        lightValue.range = glowRange;
        lightValue.intensity = glowIntensity;
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        
    }

    void LateUpdate()
    {
        GameObject key = GameObject.Find("Exit_GateKey");
        if (key != null)
        {
            flickerTimeI = Time.deltaTime * (1 - Random.Range(-flickerSpeedI, flickerSpeedI)) * Mathf.PI;
            lightValue.intensity = glowIntensity + Mathf.Sin(flickerTimeI * flickerAmount) * flickerIntensityI;
            transform.position = target.position - offset;
        }
        else
        {
            Destroy(lightValue);
        }
    }

}
