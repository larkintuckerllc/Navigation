using UnityEngine;
using UnityEngine.AI;

namespace Com.Larkintuckerllc.Navigation
{
    public class MeshParent : MonoBehaviour
    {

        NavMeshSurface _navMeshSurface;

        void Awake()
        {
            _navMeshSurface = GetComponent<NavMeshSurface>();
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
                _navMeshSurface.BuildNavMesh();
            }
        }
    }
}
