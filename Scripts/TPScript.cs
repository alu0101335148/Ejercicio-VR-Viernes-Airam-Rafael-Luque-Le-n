using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
      if (Input.GetKey(KeyCode.T)) {
        transform.position += new Vector3(0, 10, 10);
      }
    }
}
