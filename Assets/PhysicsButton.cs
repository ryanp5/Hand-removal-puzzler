using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    public GameEvent buttonPressed;
    public GameEvent buttonUnPressed;
    public Detachable box;
    private Rigidbody rigidbody;
    public float bottomStop;
    public float topStop;
    public float bottomEngage;
    public float topDisengage;
    private Vector3 startLocation;
    void Start()
    {
        startLocation = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startLocation.x, Mathf.Clamp(transform.position.y, startLocation.y - bottomStop, startLocation.y + topStop), startLocation.z);
        if (transform.position.y < startLocation.y - bottomEngage)
        {
            buttonPressed.Raise();
        }
        if (transform.position.y > startLocation.y + topDisengage)
        {
            buttonUnPressed.Raise();
        }
    }
}
