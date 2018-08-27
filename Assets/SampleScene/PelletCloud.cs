using UnityEngine;

namespace Com.Larkintuckerllc.Navigation
{
    public class PelletCloud : MonoBehaviour
    {
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
            transform.localPosition = Global.placement;
        }

    }
}
