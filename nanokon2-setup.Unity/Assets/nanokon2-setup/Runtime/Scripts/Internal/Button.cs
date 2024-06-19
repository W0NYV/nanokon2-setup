using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UniRx;

namespace W0NYV.nanoKON2
{
    public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _bg;
        [SerializeField] private Color _defColor;
        [SerializeField] private Color _pressedColor;

        private ReactiveProperty<float> _valueReactiveProperty = new ReactiveProperty<float>(0f);
        public IObservable<float> ObservableValue => _valueReactiveProperty;


        private ReactiveProperty<bool> _hasTouchedReactiveProperty = new ReactiveProperty<bool>(false);
        public IObservable<bool> ObservableHasTouched => _hasTouchedReactiveProperty;

        public void SetPressedState()
        {
            _bg.color = _pressedColor;
            _valueReactiveProperty.Value = 1f;
        }

        public void SetDefaultState()
        {
            _bg.color = _defColor;
            _valueReactiveProperty.Value = 0f;
        }

        public void OnPointerDown(PointerEventData eventData)
        {        
            SetPressedState();
            _hasTouchedReactiveProperty.Value = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            SetDefaultState();
            _hasTouchedReactiveProperty.Value = false;
        }

    }
}
