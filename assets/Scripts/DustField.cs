using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(ParticleSystem))]
public class DustField : MonoBehaviour
{
    public int numberOfDustParticles;
    public float min;
    public int seed;
    private ParticleSystem.Particle[] points;
    private BoxCollider boxCollider;
    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        CreateDustField();
    }
    private Vector3 RandomPtinBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    } 

    public void CreateDustField()
    {
        boxCollider = GetComponent<BoxCollider>();
        particleSystem = GetComponent<ParticleSystem>();
        points = new ParticleSystem.Particle[numberOfDustParticles];
        Random.InitState(seed);
        for (int i = 0; i < numberOfDustParticles; i++)
        {
            points[i].position = RandomPtinBounds(boxCollider.bounds) - transform.position;
            points[i].startSize = Random.Range(0.05f, 0.05f);
            points[i].startColor = new Color(1, 1, 1, 1);
            particleSystem.SetParticles(points, points.Length);

        }
    }
}
