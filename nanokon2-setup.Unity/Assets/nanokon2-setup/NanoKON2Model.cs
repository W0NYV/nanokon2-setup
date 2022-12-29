using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class NanoKON2Model : MonoBehaviour
    {
        private ReactiveCollection _sliderValueList = new ReactiveCollection(8);
        public ReactiveCollection SliderValueList
        {
            get => _sliderValueList;
        }

        // private void Awake() {
        //     _sliderValueList.ReplaceObservable.Subscribe(OnReplace).AddTo(gameObject);
        // }

        // private void Start() {
        //     _sliderValueList.ChangeValue(1, 1f);
        // }

    } 
}