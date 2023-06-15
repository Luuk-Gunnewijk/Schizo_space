using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast_Script : MonoBehaviour
{
    InteractButton_Script myInteractButton_Script;

    [SerializeField] GameObject myPlayer;

    [SerializeField] Transform level_Teleporter_0;
    [SerializeField] Transform level_Teleporter_1;
    [SerializeField] Transform level_Teleporter_2;

    [SerializeField] LayerMask myInteractLayer;
    [SerializeField] LayerMask myTestButtonLayer;
    [SerializeField] LayerMask Level_0_Layer;
    [SerializeField] LayerMask Level_1_Layer;
    [SerializeField] LayerMask Level_2_Layer;
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
            isMyInterractButton = true;
            myInteractButton_Script.IsInteractButtonTrue = true;
        }
        else if (Physics.Raycast(ray, out hitinfo, 20f, Level_0_Layer, QueryTriggerInteraction.Ignore))
        {
            myInteractButton_Script.IsInteractButtonTrue = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                myPlayer.transform.position = level_Teleporter_0.transform.position;
                Debug.Log("Level_0");
            }
        }
        else if (Physics.Raycast(ray, out hitinfo, 20f, Level_1_Layer, QueryTriggerInteraction.Ignore))
        {
            myInteractButton_Script.IsInteractButtonTrue = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Level_1");
            }
        }
        else if (Physics.Raycast(ray, out hitinfo, 20f, Level_2_Layer, QueryTriggerInteraction.Ignore))
        {
            myInteractButton_Script.IsInteractButtonTrue = true;
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                myPlayer.transform.position = level_Teleporter_2.transform.position;
                Debug.Log("Level_2");
            }
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
