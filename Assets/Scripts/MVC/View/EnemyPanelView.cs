using System.Globalization;
using MVC.Model;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class EnemyPanelView : MonoBehaviour
    {
        public Transform mUIAttackPoint;
        [SerializeField] private Slider mUIBloodSli;
        [SerializeField] private Text mUIBloodTe;

        private ArmyModel mData;

        public void Init(ArmyModel data)
        {
            mData = data;
            mUIBloodTe.text = mData.MaxHp.ToString();
            mUIBloodSli.value = 1f;
        }

        public void RefreshBlood()
        {
            float curVal = int.Parse(mUIBloodTe.text) - mData.Atk;

            mUIBloodTe.text = curVal.ToString(CultureInfo.InvariantCulture);

            var value = curVal <= 0 ? 0 : curVal / mData.MaxHp;

            mUIBloodSli.value = value;

            if (value <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}