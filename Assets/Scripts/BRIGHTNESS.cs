using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BRIGHTNESS : MonoBehaviour
{
    public Slider brightnessSLider;

    public PostProcessProfile brightness;
    public PostProcessProfile layer;

    AutoExposure exposure;

   
    void Start()
    {
        brightness.TryGetSettings(out exposure);
    }

   public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = 0.05f;
        }
    }
}
