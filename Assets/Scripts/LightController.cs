using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Light lightValue;
    public float torchAngle;
    public float torchIntensity;

    private float flickerTimeI;
    private float flickerTimeA;
    public float flickerAmount = 0.2f;
    public float flickerIntensityI = 3.0f;
    public float flickerIntensityA = 5.0f;
    public float flickerSpeedI;
    public float flickerSpeedA;


    // Start is called before the first frame update
    private void Start()
    {
        lightValue = GetComponent<Light>();
        lightValue.type = LightType.Spot;
        lightValue.spotAngle = torchAngle;
        lightValue.intensity = torchIntensity;
        transform.position = new Vector3(target.position.x, target.position.y + 12, target.position.z);
        
        
    }

    void Update()
    {
        flickerTimeI = Time.deltaTime * (1 - Random.Range(-flickerSpeedI, flickerSpeedI)) * Mathf.PI;
        flickerTimeA = Time.deltaTime/2 * (1 - Random.Range(-flickerSpeedA, flickerSpeedA)) * Mathf.PI;
        lightValue.intensity = torchIntensity + Mathf.Sin(flickerTimeI * flickerAmount) * flickerIntensityI;
        lightValue.spotAngle = torchAngle + Mathf.Sin(flickerTimeA * flickerAmount) * flickerIntensityA;
    }

    // Update is called once per frame
    void LateUpdate()
    {
              
        transform.position = target.position - offset;
        transform.LookAt(target);

    }
}
