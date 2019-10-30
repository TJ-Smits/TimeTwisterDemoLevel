using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManipulation : MonoBehaviour
{

    public float InteractionDistance = 3f;

    public Image crosshair;

    private Interactable interactable;

    private new Camera camera;

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
                    interactable = hit.collider.GetComponent<Interactable>();
                    interactable.SetGravity(false);
                    Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 2f);
                    interactable.MoveToTarget(camera.ScreenToWorldPoint(position));
                }
            }
        } else
        {
            if (crosshair.enabled)
            {
                interactable.SetGravity(true);
                crosshair.enabled = false;
            }
        }
    }
}
