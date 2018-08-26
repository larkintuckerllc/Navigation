using UnityEngine;

namespace Com.Larkintuckerllc.Navigation
{
    public class MainCamera : MonoBehaviour
    {
        static int LAYER_MASK = 1;
        float _last = 0.0f;

        private void Awake()
        {
            Global.mainCameraForward = transform.forward;
            Global.mainCameraPosition = transform.position;
            Global.mainCameraRotation = transform.rotation;
        }

        void Update()
        {
            Global.mainCameraForward = transform.forward;
            Global.mainCameraPosition = transform.position;
            Global.mainCameraRotation = transform.rotation;
            var now = Time.time;
            if (Global.mode == Global.Mode.Play && ((now - _last) >= 1.0f))
            {
                Cast();
            }
        }

        void Cast()
        {
            _last = Time.time;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LAYER_MASK))
            {
                Global.hit= hit.point;
                if (!Global.hitSet) {
                    Global.hitSet = true;
                    EventManager.TriggerEvent(Global.EVENT_HIT_SET);
                }
            }
        }
    }
}
