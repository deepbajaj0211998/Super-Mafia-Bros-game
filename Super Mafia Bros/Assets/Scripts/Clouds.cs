using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    public float speed;
    private float xDir;

    // Start is called before the first frame update
    void Start()
    {
        xDir = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        xDir -= Time.deltaTime * speed;
        transform.position = new Vector3(xDir, transform.position.y, transform.position.z);
    }
}
