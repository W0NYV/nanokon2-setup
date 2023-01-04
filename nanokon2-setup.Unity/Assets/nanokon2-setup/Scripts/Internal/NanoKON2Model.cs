using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class NanoKON2Model : MonoBehaviour
    {

        public static NanoKON2Model instance;
        public Model guiModel = new Model();
        public Model model = new Model();

        private void Awake() {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    } 
}