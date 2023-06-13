using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast_Script : MonoBehaviour
{
    InteractButton_Script myInteractButton_Script;

    [SerializeField] LayerMask myInteractLayer;
    [SerializeField] LayerMask myTestButtonLayer;
    RaycastHit hitinfo;

    public bool isMyInterractButton = false;

    private void Awake()
    {
        myInteractButton_Script = FindAnyObjectByType<InteractButton_Script>();
    }
    void Update()
    {
        Raycast();
    }

    void Raycast()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hitinfo, 20f, myInteractLayer, QueryTriggerInteraction.Ignore))
        {
            isMyInterractButton = true;
            myInteractButton_Script.IsInteractButtonTrue = true;
        }
        else if (Physics.Raycast(ray, out hitinfo, 20f, myTestButtonLayer, QueryTriggerInteraction.Ignore))
        {

            myInteractButton_Script.IsInteractButtonTrue = true;
        }
        else
        {
            isMyInterractButton = false;
            myInteractButton_Script.IsInteractButtonTrue = false;
        }

        

        //Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * hitinfo.distance, Color.green);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.blue);
    }
}
