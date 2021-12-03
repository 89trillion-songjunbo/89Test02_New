using MVC.Model;
using MVC.View;
using UnityEngine;

namespace MVC.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerView mUIPlayerView;

        [SerializeField] private EnemyPanelView mUIEnemyPanelView;

        private PersonModel personModel;
        private PersonModel PersonModel => personModel ?? (personModel = new PersonModel());

        private void Start()
        {
            if (PersonModel.personModel == null || PersonModel.personModel.Count <= 0)
            {
                return;
            }

            mUIPlayerView.Init(PersonModel.personModel[0]);
            mUIEnemyPanelView.Init(PersonModel.personModel[0]);
            mUIPlayerView.SetEndPos(mUIEnemyPanelView.mUIAttackPoint);
            mUIPlayerView.EventBloodLess += mUIEnemyPanelView.RefreshBlood;
        }
    }
}