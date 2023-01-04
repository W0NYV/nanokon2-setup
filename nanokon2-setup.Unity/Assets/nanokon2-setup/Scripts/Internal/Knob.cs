using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace W0NYV.nanoKON2
{
    public class Knob : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [SerializeField] private Image _ring;
        [SerializeField] private GameObject _handle;
        public float value { get; private set; }

        private float increment = 0.01f;

        public void SetValue(float v)
        {
            value = Mathf.Clamp(v, 0f, 1f);

            _ring.fillAmount = value;
            _handle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, value * -360f));
        }
        
        private void AddValue(float v)
        {
            value += v;
            value = Mathf.Clamp(value, 0f, 1f);

            _ring.fillAmount = value;
            _handle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, value * -360f));
        }

        //TODO：今のままだと動きが少ない方が変化する
        public void OnDrag(PointerEventData eventData)
        {
            AddValue(increment * Mathf.Sign(eventData.delta.y));
        }

        public void OnBeginDrag(PointerEventData eventData){}
        public void OnEndDrag(PointerEventData eventData){}

    }
}
