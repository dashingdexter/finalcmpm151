using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    Rigidbody r;
    // Start is called before the first frame update
    private bool collected;

    void Start()
    {
        collected = false;
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(2f, 0, 0));

    }
    // pick up
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
            other.gameObject.SetActive(false);
    }
}
