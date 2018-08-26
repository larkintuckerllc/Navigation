using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace Com.Larkintuckerllc.Navigation
{
    public class MLSpatialMapper2 : MonoBehaviour
    {

        MLSpatialMapper _mLSpatialMapper;
        [SerializeField, Tooltip("The material to apply for occlusion.")]
        Material _occlusionMaterial;

        void Awake()
        {
            _mLSpatialMapper = GetComponent<MLSpatialMapper>();
        }

		void OnEnable()
        {
            EventManager.StartListening(Global.EVENT_MODE_UPDATE, HandleModeUpdate);
        }

        void OnDisable()
        {
            EventManager.StopListening(Global.EVENT_MODE_UPDATE, HandleModeUpdate);
        }

        void HandleModeUpdate()
        {
            if (Global.mode == Global.Mode.Play)
            {
                foreach (GameObject fragment in _mLSpatialMapper.meshIdToGameObjectMap.Values)
                {
                    var fragmentRender = fragment.GetComponent<MeshRenderer>();
                    fragmentRender.material = _occlusionMaterial;
                }
                _mLSpatialMapper.enabled = false;
            }
        }
    }
}
