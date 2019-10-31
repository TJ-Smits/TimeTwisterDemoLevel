using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManipulation : MonoBehaviour
{

    public float InteractionDistance = 3f;

    public Image crosshair;

    private new Camera camera;

    private Interactable interactedObject;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        crosshair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Center of screen
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                crosshair.enabled = true;

                if (Input.GetButtonDown("Fire1"))
                {
                    if (!interactedObject)
                    {
                        interactedObject = hit.collider.GetComponent<Interactable>();
                        interactedObject.SetGravity(false);
                    }
                    else
                    {
                        interactedObject.SetGravity(true);
                        interactedObject = null;
                    }
                }

                if (interactedObject)
                {
                    Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 2f);
                    interactedObject.MoveToTarget(camera.ScreenToWorldPoint(position));
                }
            }
        }
        else
        {
            if (crosshair.enabled)
            {
                if (interactedObject)
                {
                    interactedObject.SetGravity(true);
                    interactedObject = null;
                }
                crosshair.enabled = false;
            }
        }
    }
}
