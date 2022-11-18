using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScaling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.tag == "Monster") {
        GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg");
        foreach (GameObject egg in eggs) {
          egg.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        }
      }
    }
}
