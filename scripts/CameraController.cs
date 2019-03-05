using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset, newPosition;
    public float smoothing;
    public Vector2 minimumBoundary, maximumBoundary;

    // Use this for initialization
    void Start()
    {
        offset = this.transform.position - target.transform.position;

    }
    void FixedUpdate()
    {
        newPosition = target.transform.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, newPosition, smoothing * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
        transform.position = new Vector3
       (Mathf.Clamp(transform.position.x, minimumBoundary.x, maximumBoundary.x), Mathf.Clamp(transform.position.y, minimumBoundary.y, maximumBoundary.y), transform.position.z);
    }
}
