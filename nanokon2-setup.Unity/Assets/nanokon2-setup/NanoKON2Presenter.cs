using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class NanoKON2Presenter : MonoBehaviour
    {

        [SerializeField] private NanoKON2Handler _nanoKON2Handler;
        [SerializeField] private NanoKON2Model _nanoKON2Model;
        [SerializeField] private Slider _slider;

        void Start()
        {
            _nanoKON2Handler.onSliderMoved[0].AddListener(val => {
                _nanoKON2Model.SliderValueList.ChangeValue(0, val);
            });

            _nanoKON2Model.SliderValueList.ReplaceObservable.Subscribe(replaceEvent => {
                _slider.value = replaceEvent.NewValue;
                // Debug.Log(replaceEvent.Index + "番目の値が" + replaceEvent.OldValue + "→" + replaceEvent.NewValue + "に変更");
            }).AddTo(this);

            _slider.OnValueChangedAsObservable()
                .Subscribe(x => {
                    _nanoKON2Model.SliderValueList.ChangeValue(0, x);
                })
                .AddTo(this);

        }

        private void Update() {
            Debug.Log(_nanoKON2Model.SliderValueList.ValueList[0]);
        }

    }
} 
