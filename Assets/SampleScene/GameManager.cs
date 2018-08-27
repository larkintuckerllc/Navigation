using UnityEngine;

namespace Com.Larkintuckerllc.Navigation
{
    public class GameManager : MonoBehaviour
    {
        static string CHICKEN_PREFAB_NAME = "Chicken";
        static Vector3 CHICKEN_POSITION = new Vector3(0.0f, 0.35f, 0.0f);
        static string PELLET_PREFAB_NAME = "Pellet";
        static Vector3 PELLET_POSITION_OFFSET = new Vector3(0.0f, 0.1f, 0.0f);
        static string PELLET_CLOUD_PREFAB_NAME = "PelletCloud";
        static string SHAKER_PREFAB_NAME = "Shaker";
        static Vector3 SHAKER_POSITION_OFFSET = new Vector3(0.0f, 1.0f, 0.0f);

        bool _placementSet = false;

        void OnEnable()
        {
            EventManager.StartListening(Global.EVENT_HIT_SET, HandleHitSet);
            EventManager.StartListening(Global.EVENT_MODE_UPDATE, HandleModeUpdate);
            EventManager.StartListening(Global.EVENT_PLACEMENT_UPDATE, HandlePlacementUpdate);
        }

        void OnDisable()
        {
            EventManager.StopListening(Global.EVENT_HIT_SET, HandleHitSet);
            EventManager.StopListening(Global.EVENT_MODE_UPDATE, HandleModeUpdate);
            EventManager.StopListening(Global.EVENT_PLACEMENT_UPDATE, HandlePlacementUpdate);
        }

        void HandleHitSet()
        {
            GameObject shaker = (GameObject)Instantiate(Resources.Load(SHAKER_PREFAB_NAME));
            Transform shakerTransform = shaker.GetComponent<Transform>();
            shakerTransform.localPosition = Global.hit + SHAKER_POSITION_OFFSET;
        }

        void HandleModeUpdate()
        {
            GameObject chicken = (GameObject)Instantiate(Resources.Load(CHICKEN_PREFAB_NAME));
            Transform chickenTransform = chicken.GetComponent<Transform>();
            chickenTransform.localPosition = CHICKEN_POSITION;
        }

        void HandlePlacementUpdate()
        {
            if (_placementSet)
            {
                return; 
            }
            _placementSet = true;
            GameObject pellet = (GameObject)Instantiate(Resources.Load(PELLET_PREFAB_NAME));
            Transform pelletTransform = pellet.GetComponent<Transform>();
            pelletTransform.localPosition = Global.placement + PELLET_POSITION_OFFSET;
            GameObject pelletCloud = (GameObject)Instantiate(Resources.Load(PELLET_CLOUD_PREFAB_NAME));
            Transform pelletCloudTransform = pelletCloud.GetComponent<Transform>();
            pelletCloudTransform.localPosition = Global.placement;
        }
    }
}