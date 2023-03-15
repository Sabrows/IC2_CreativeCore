using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightManager : MonoBehaviour
{

    [SerializeField] private Material _sunnyDaySkybox;
    [SerializeField] private Material _cozyNightSkybox;
    [SerializeField] private Light _sunnyDayDirectionalLight;
    [SerializeField] private Light _cozyNightDirectionalLight;
    [SerializeField] private Light[] _nightLights;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("switching to night");
            //change skybox
            UnityEngine.RenderSettings.skybox = _cozyNightSkybox;

            //activate night lights
            foreach (Light light in _nightLights)
            {
                light.enabled = true;
            }
            
            //change directional light
            if (_sunnyDayDirectionalLight.enabled)
            {
                _sunnyDayDirectionalLight.enabled = false;
                _cozyNightDirectionalLight.enabled = true;
            }
            
            //TODO: at night deactivate LightProbes
        }
    }
}
