# Ejercicio VR Viernes

## Autor: Airam Rafael Luque León

## Actividades

### Crear una escena que incluya un mostruo, cofres, arañas y huevos de los paquetes enlazados.

![exercise1](/img/1.jpg)

### Crear un script para teletransportar al monstruo a cada vez que se pulse la tecla T

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour
{
  void Start() {}

  void Update() {}

  void FixedUpdate() {
    if (Input.GetKey(KeyCode.T)) {
      transform.position += new Vector3(0, 0, 10);
    }
  }
}
```

### Crear un script que aumente las dimensiones de los huevos de las arañas cada vez que el monster colisione con el cofre. El cofre debe ser desplazado con física.

MonsterController.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
  Rigidbody playerRigidbody;
  private float translationSpeed;
  private Vector3 rotationSpeed;
  public float life = 100.0f;

  void Start() {
    playerRigidbody = GetComponent<Rigidbody>();
    translationSpeed = 15f;
    rotationSpeed = new Vector3(0, 2f, 0);
  }

  void Update() {}

  void FixedUpdate() {
    playerRigidbody.AddRelativeForce(0, 0, translationSpeed * Input.GetAxis("Vertical"));
    Quaternion rotation = Quaternion.Euler(Input.GetAxis("Horizontal") * rotationSpeed);
    playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
  }
}
```

EggScalling.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScaling : MonoBehaviour {
  void Start() {}

  // Update is called once per frame
  void Update() {}

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Monster") {
      GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg");
      foreach (GameObject egg in eggs) {
        egg.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
      }
    }
  }
}
```

### Crear un script que al pasar a una distancia menor que una dada de las arañas, reste vida al monstruo.

AttackScript.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
  void Start() {}

  // Update is called once per frame
  void Update() {}

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Monster") {
      other.gameObject.GetComponent<MonsterController>().life -= 10;
    }
  }
}
```

### Configurar el proyecto para funcionar con CardBoard. 

### Implementar una mecánica en la que el jugador al fijar la mirada sobre uno de los cofres, las arañas de color rojo se roten y las verdes salten.

````csharp
...
    public void OnPointerEnter()
    {
      Debug.Log("Test");
      GameObject[] redSpiders = GameObject.FindGameObjectsWithTag("RedSpider");
      GameObject[] greemSpiders = GameObject.FindGameObjectsWithTag("GreenSpider");
      foreach (GameObject redSpider in redSpiders) {
        Rigidbody rb = redSpider.GetComponent<Rigidbody>();
        Vector3 rotationSpeed = new Vector3(0, 100f, 0);
        Quaternion rotation = Quaternion.Euler(rotationSpeed);
        rb.MoveRotation(rb.rotation * rotation);
      }
      foreach (GameObject greenSpider in greemSpiders) {
        Debug.Log("Doing something");
        greenSpider.GetComponent<Rigidbody>().AddRelativeForce(0, 1000, 0);
      }
    }
...
```