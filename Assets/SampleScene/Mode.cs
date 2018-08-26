using UnityEngine;
using UnityEngine.UI;

namespace Com.Larkintuckerllc.Navigation
{
    public class Mode : MonoBehaviour
    {

        Text _text;

        void Awake()
        {
            _text = GetComponent<Text>();
            _text.text = Global.mode.ToString();
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
            _text.text = Global.mode.ToString();
        }
    }
}
