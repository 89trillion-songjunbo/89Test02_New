using System;
using DG.Tweening;
using Helper;
using MVC.Model;
using UnityEngine;

namespace MVC.View
{
    /// <summary>
    /// 玩家类
    /// </summary>
    public class PlayerView : MonoBehaviour
    {
        public AnimEvent mAnimPanel;
        public Animator perAnim;
        [SerializeField] private GameObject mUiSwordObj;
        [SerializeField] private Transform mUiSwordParentPos;

        private Transform mUiSwordEndPos;
        public Action EventBloodLess;

        private ArmyModel mData;

        public void Init(ArmyModel data)
        {
            mData = data;
            mAnimPanel.EventAnimFinish += CreteSword;
        }

        private float timer;
        private static readonly int Idle = Animator.StringToHash("idle");
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Run = Animator.StringToHash("run");

        private void Update()
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.A) && timer >= mData.ShootSpeed)
            {
                perAnim.SetTrigger(Attack);
                timer = 0;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                perAnim.SetBool(Run, true);
            }
            else if (Input.GetKeyUp(KeyCode.R))
            {
                perAnim.SetBool(Run, false);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                perAnim.SetTrigger(Idle);
            }
        }

        private void CreteSword()
        {
            var swordGo = Instantiate(mUiSwordObj, mUiSwordParentPos);
            swordGo.transform.localPosition = Vector3.zero;
            swordGo.transform.localRotation = Quaternion.identity;
            swordGo.transform.localScale = Vector3.one;

            swordGo.transform.DOMove(mUiSwordEndPos.position, 1f).OnComplete(() =>
            {
                EventBloodLess?.Invoke();
                Destroy(swordGo);
            });
        }

        public void SetEndPos(Transform endPos)
        {
            mUiSwordEndPos = endPos;
        }
    }
}