using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseGenerator : MonoBehaviour
{
    private ComputeShader noise = Resources.Load<ComputeShader>("Shader/ComputeShader/Noise");
    public int resolution = 256;
    private RenderTexture noiseTexture;
    
    
}
