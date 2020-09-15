using UnityEngine;
using UnityEngine.UI;

namespace CircleMenu.Utils
{
    public class RadialLayout : LayoutGroup
    {
        #region FIELDS

        [Header("Editor settings")]
        [SerializeField]
        private float _radius = default;

        [Range(0f, 360f)]
        [SerializeField]
        private float _minAngle = default;

        [Range(0f, 360f)]
        [SerializeField]
        private float _maxAngle = default;

        [Range(-360f, 360f)]
        [SerializeField]
        private float _startAngle = default;

        #endregion

        #region PROPERTIES

        public float Angle
        {
            get => _startAngle;
            set => _startAngle = value;
        }

        public float Radius
        {
            get => _radius;
            private set => _radius = value;
        }

        #endregion

        #region UNITY_METHODS

        public override void SetLayoutHorizontal()
        {
        }

        public override void SetLayoutVertical()
        {
        }

        public override void CalculateLayoutInputVertical()
        {
            CalculateRadial();
        }

        public override void CalculateLayoutInputHorizontal()
        {
            CalculateRadial();
        }
//
// #if UNITY_EDITOR
//         protected override void OnValidate()
//         {
//             base.OnValidate();
//             CalculateRadial();
//         }
// #endif

        #endregion

        #region PRIVATE_METHODS

        private void CalculateRadial()
        {
            m_Tracker.Clear();

            if (transform.childCount == 0)
            {
                return;
            }

            var fOffsetAngle = ((_maxAngle - _minAngle)) / (transform.childCount);
            var fAngle = _startAngle;

            for (var i = 0; i < transform.childCount; i++)
            {
                var child = (RectTransform) transform.GetChild(i);
                if (child == null) continue;
                m_Tracker.Add(this, child,
                    DrivenTransformProperties.Anchors |
                    DrivenTransformProperties.AnchoredPosition |
                    DrivenTransformProperties.Pivot);
                var vPos = new Vector3(Mathf.Cos(fAngle * Mathf.Deg2Rad), Mathf.Sin(fAngle * Mathf.Deg2Rad), 0);
                child.localPosition = vPos * _radius;
                child.anchorMin = child.anchorMax = child.pivot = new Vector2(0.5f, 0.5f);
                fAngle += fOffsetAngle;
            }
        }

        #endregion
    }
}