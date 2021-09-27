using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotationspeed=100f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f,0f,rotationspeed*Time.deltaTime);
    }
}
