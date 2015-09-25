using UnityEngine;
using System.Collections;

public class FishEyeController : MonoBehaviour {

    public FishEyeAngularUVGenerator fishEyeAngularUVGenerator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(FishEyeAngularUVGenerator.FishEyeMethod.EquiDistance);

            fishEyeAngularUVGenerator.SetFishEyeUV(FishEyeAngularUVGenerator.FishEyeMethod.EquiDistance);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(FishEyeAngularUVGenerator.FishEyeMethod.EquiAngle);

            fishEyeAngularUVGenerator.SetFishEyeUV(FishEyeAngularUVGenerator.FishEyeMethod.EquiAngle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(FishEyeAngularUVGenerator.FishEyeMethod.Ortho);

            fishEyeAngularUVGenerator.SetFishEyeUV(FishEyeAngularUVGenerator.FishEyeMethod.Ortho);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(FishEyeAngularUVGenerator.FishEyeMethod.Stereo);

            fishEyeAngularUVGenerator.SetFishEyeUV(FishEyeAngularUVGenerator.FishEyeMethod.Stereo);
        }
    }
}
