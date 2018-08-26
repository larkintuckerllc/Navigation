using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Larkintuckerllc.Navigation
{
    public class Pellet : MonoBehaviour
    {
        static Vector3 POSITION_OFFSET = new Vector3(0.0f, 0.1f, 0.0f);

        void OnEnable()
        {
            EventManager.StartListening(Global.EVENT_PLACEMENT_UPDATE, HandlePlacementUpdate);
        }

        void OnDisable()
        {
            EventManager.StopListening(Global.EVENT_PLACEMENT_UPDATE, HandlePlacementUpdate);
        }

        void HandlePlacementUpdate()
        {
            transform.localPosition = Global.placement + POSITION_OFFSET;
        }

    }
}
