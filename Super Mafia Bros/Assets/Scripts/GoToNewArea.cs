using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNewArea : MonoBehaviour
{

    public GameObject sp1, sp2;

    // Start is called before the first frame update
    void Start()
    {
        sp1 = this.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
