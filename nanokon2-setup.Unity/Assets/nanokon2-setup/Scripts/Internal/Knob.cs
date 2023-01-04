using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;
using System;

namespace W0NYV.nanoKON2
{
    public class Knob : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [SerializeField] private Image _ring;
        [SerializeField] private GameObject _handle;

        private ReactiveProperty<float> _valueReactiveProperty = new ReactiveProperty<float>(0f);
        public IObservable<float> ObservableValue => _valueReactiveProperty;

        private ReactiveProperty<bool> _hasTouchedReactiveProperty = new ReactiveProperty<bool>(false);
        public IObservable<bool> ObservableHasTouched => _hasTouchedReactiveProperty;

        private float increment = 0.01f;

        public void SetValue(float v)
        {
            _valueReactiveProperty.Value = Mathf.Clamp(v, 0f, 1f);

            _ring.fillAmount = _valueReactiveProperty.Value;
            _handle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _valueReactiveProperty.Value * -360f));
        }
        
        private void AddValue(float v)
        {
            _valueReactiveProperty.Value += v;
            _valueReactiveProperty.Value = Mathf.Clamp(_valueReactiveProperty.Value, 0f, 1f);

            _ring.fillAmount = _valueReactiveProperty.Value;
            _handle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _valueReactiveProperty.Value * -360f));
        }

        //TODO：今のままだと動きが少ない方が変化する
        public void OnDrag(PointerEventData eventData)
        {
            _hasTouchedReactiveProperty.Value = true;
            AddValue(increment * Mathf.Sign(eventData.delta.y));
        }

        public void OnBeginDrag(PointerEventData eventData){}

        public void OnEndDrag(PointerEventData eventData)
        {
            _hasTouchedReactiveProperty.Value = false;
        }

    }
}
