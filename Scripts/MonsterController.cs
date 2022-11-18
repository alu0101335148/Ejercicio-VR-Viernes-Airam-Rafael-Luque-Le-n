using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
  Rigidbody playerRigidbody;
  private float translationSpeed;
  private Vector3 rotationSpeed;

  public float life = 100.0f;

  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();
    translationSpeed = 15f;
    rotationSpeed = new Vector3(0, 2f, 0);
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void FixedUpdate() {
    playerRigidbody.AddRelativeForce(0, 0, translationSpeed * Input.GetAxis("Vertical"));
    Quaternion rotation = Quaternion.Euler(Input.GetAxis("Horizontal") * rotationSpeed);
    playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
  }

}
