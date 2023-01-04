using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UnityEngine.EventSystems;

namespace W0NYV.nanoKON2
{
    public class SliderCustom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private ReactiveProperty<bool> _hasTouchedReactiveProperty = new ReactiveProperty<bool>(false);
        public IObservable<bool> ObservableHasTouched => _hasTouchedReactiveProperty;
        
        private ReactiveProperty<float> _valueReactiveProperty = new ReactiveProperty<float>(0f);
        public IObservable<float> ObservableValue => _valueReactiveProperty;

        public Slider slider;

        private void Awake() {
            TryGetComponent<Slider>(out slider);

            slider.OnValueChangedAsObservable()
                .Subscribe(x => _valueReactiveProperty.Value = x);
        }

        public void OnPointerDown(PointerEventData eventData)
        {        
            _hasTouchedReactiveProperty.Value = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _hasTouchedReactiveProperty.Value = false;
        }
    }
}
