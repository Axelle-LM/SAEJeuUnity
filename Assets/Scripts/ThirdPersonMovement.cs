using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMouvement : MonoBehaviour
{   
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
// Bullet
    public GameObject BulletPrefab;
    public Transform FirePosition;

// Rendre les mouvement de rotation plus smooth
public float turnSmoothTime = 0.1f;
public float turnSmoothVelocity;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // Rotate le personnage ne fonction de la direction et de la cam
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            // float y = Input.GetAxis("Mouse x") * Speed;
            // controller.transform.eulerAngles = new Vector3(0, controller.transform.eulerAngles.y + y, 0);
        }
       if (Input.GetMouseButtonDown(0))
{
    GameObject bullet = Instantiate(BulletPrefab, FirePosition.position, Quaternion.identity);

    // Récupérer la position de la caméra
    Event m_Event = Event.current;
  if (m_Event.type == EventType.MouseDown) 
   {
        // Calculer la direction depuis la caméra vers le point visé
        Vector3 shootDirection = transform.up;

        // Appliquer une force au projectile dans la direction calculée
        bullet.GetComponent<Rigidbody>().AddForce(transform.up * 5000);
    }
    else
    {
        Debug.LogError("Main camera not found!");
    }
}
}
}
