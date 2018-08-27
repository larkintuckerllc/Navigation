using UnityEngine;

namespace Com.Larkintuckerllc.Navigation
{
    public class Shaker : MonoBehaviour
    {
        float SPEED = 1.0f;
        Vector3 SHAKER_POSITION_OFFSET = new Vector3(0.0f, 1.0f, 0.0f);

        void Update()
        {
            float step = SPEED * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Global.hit + SHAKER_POSITION_OFFSET, step);
        }
    }
}
