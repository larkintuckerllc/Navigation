using UnityEngine;
using UnityEngine.AI;

namespace Com.Larkintuckerllc.Navigation
{
    public class Chicken : MonoBehaviour
    {
        Animator _animator;
        NavMeshAgent _navMeshAgent;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

		void OnEnable()
        {
            EventManager.StartListening(Global.EVENT_PLACEMENT_UPDATE, HandlePlacementUpdate);
        }

        void Update()
        {
            bool isWalking = _navMeshAgent.velocity != Vector3.zero;
            _animator.SetBool("IsWalking", isWalking);
        }

		void OnDisable()
        {
            EventManager.StopListening(Global.EVENT_PLACEMENT_UPDATE, HandlePlacementUpdate);
        }

        void HandlePlacementUpdate()
        {
            _navMeshAgent.SetDestination(Global.placement);
        }
    }
}