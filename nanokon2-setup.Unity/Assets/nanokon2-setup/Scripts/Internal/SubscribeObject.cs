using UnityEngine;
using UnityEngine.Events;

namespace W0NYV.nanoKON2
{
	[System.Serializable]
    public class SubscribeObject
    {
        public UnityEvent<float> uniEvent;
        public Controller controller;
        public int index;
    }
}

