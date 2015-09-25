using UnityEngine;
using System.Collections;

public class FishEyeAngularUVGenerator : MonoBehaviour {

    public enum FishEyeMethod { EquiDistance, EquiAngle, Ortho, Stereo };

    public FishEyeMethod fishEyeMethod = FishEyeMethod.EquiDistance;

    public Vector2 uvCenter = 0.5f * Vector2.one;

	// Use this for initialization
    public void SetFishEyeUV(FishEyeMethod fishEyeMethod)
    {
        this.fishEyeMethod = fishEyeMethod;

        Vector3[] vertices = GetComponent<MeshFilter>().mesh.vertices;

        Vector2[] newUV = new Vector2[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector2 direc = vertices[i];

            direc = direc.normalized;

            Vector3 p = vertices[i];

            float theta = Mathf.Atan(Mathf.Sqrt(p.x * p.x + p.y * p.y) / p.z);

            float phi = Mathf.Atan(p.y / p.x);

            if (float.IsNaN(theta)) theta = 0.0f;
            
            if (float.IsNaN(phi)) phi = 0.0f;

            if (fishEyeMethod == FishEyeMethod.EquiDistance)
                newUV[i] = uvCenter - 0.5f * direc * theta / (0.5f * Mathf.PI);
            else if (fishEyeMethod == FishEyeMethod.EquiAngle)
                newUV[i] = uvCenter - 0.5f * direc * Mathf.Sin(theta * 0.5f) * (Mathf.Sqrt(2.0f));
            else if(fishEyeMethod == FishEyeMethod.Stereo)
                newUV[i] = uvCenter - 0.5f * direc * Mathf.Tan(theta * 0.5f) ;
            else if (fishEyeMethod == FishEyeMethod.Ortho)
                newUV[i] = uvCenter - 0.5f * direc * Mathf.Sin(theta);
        }

        GetComponent<MeshFilter>().mesh.uv = newUV;
	}
}
