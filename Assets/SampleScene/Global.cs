using UnityEngine;

namespace Com.Larkintuckerllc.Navigation
{
    public static class Global
    {
        public enum Mode { Start, Play };
        static public string EVENT_HIT_SET = "HIT_SET";
        static public string EVENT_MODE_UPDATE = "MODE_UPDATE";
        static public string EVENT_PLACEMENT_UPDATE = "PLACEMENT_UPDATE";
        static public Mode mode = Mode.Start;
        static public Vector3 hit;
        static public bool hitSet = false;
        static public Vector3 placement;
    }
}