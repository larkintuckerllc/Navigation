using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace Com.Larkintuckerllc.Navigation
{
    public class KeyPoseHandler : MonoBehaviour
    {
        static MLHandKeyPose KEY_POSE = MLHandKeyPose.Ok;
        static float KEY_POSE_CONFIDENCE_THRESHOLD = 0.5f;
        bool _first = true;
        bool _posed = false;

        void Awake()
        {
            MLResult result = MLHands.Start();
            if (!result.IsOk)
            {
                Debug.LogError("Error starting MLHand, disabling script.");
                enabled = false;
                return;
            }
            var enabledPoses = new MLHandKeyPose[] {
                KEY_POSE
            };
            MLHands.KeyPoseManager.EnableKeyPoses(enabledPoses, true);
        }

        void Update()
        {
            if (_first)
            {
                _posed = Posed(); // DOESN'T RETURN CORRECTLY UNTIL UPDATE
                _first = false;
                return;
            }
            var newPosed = Posed();
            if (newPosed == _posed)
            {
                return;
            }
            _posed = newPosed;
            if (!_posed) { return; }
            switch (Global.mode) {
                case Global.Mode.Start:
                    Global.mode = Global.Mode.Play;
                    EventManager.TriggerEvent(Global.EVENT_MODE_UPDATE);
                    break;
                case Global.Mode.Play:
                    if (!Global.hitSet)
                    {
                        break;
                    }
                    Global.placement = Global.hit;
                    EventManager.TriggerEvent(Global.EVENT_PLACEMENT_UPDATE);
                    break;
            }
        }

        void OnDestroy()
        {
            MLHands.Stop();
        }

        bool Posed()
        {
            var hand = MLHands.Right;
            return (
                hand.KeyPose == KEY_POSE &&
                hand.KeyPoseConfidence > KEY_POSE_CONFIDENCE_THRESHOLD
            );
        }
    }
}
