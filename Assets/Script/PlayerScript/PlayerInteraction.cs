using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        Interaction(collision,true);
    }
/*    private void OnCollisionStay(Collision collision)
    {
        Interaction(collision,true);
    }*/

    private void OnCollisionExit(Collision collision)
    {
        Interaction(collision,false);
    }


    private void Interaction(Collision collision, bool Key)
    {
        if(collision.gameObject.tag == "InteractionObj")
        {
            collision.gameObject.GetComponent<NPCScript>().CanInteration = Key;
        }
    }

}
