using System;
using System.Collections.Generic;
using TableConfig;

namespace MVC.Model
{
    public class PersonModel
    {
        private ITable2Data<ArmyModel> personModelTable;
        public List<ArmyModel> personModel;

        private ITable2Data<ArmyModel> PersonModelTable =>
            personModelTable ?? (personModelTable = new TableManager<ArmyModel>());

        private List<ArmyModel> GetPersonModel()
        {
            return personModel ?? (personModel = PersonModelTable.GetAllModel());
        }

        private Dictionary<int, ArmyModel> personModelDic;

        private void GetPersonModelDic()
        {
            if (personModelDic != null)
            {
                return;
            }

            personModelDic = new Dictionary<int, ArmyModel>();
            var list = GetPersonModel();
            foreach (var item in list)
            {
                personModelDic.Add(item.id, item);
            }
        }

        public PersonModel()
        {
            GetPersonModelDic();
            GetPersonModel();
        }
    }

    [Serializable]
    public class ArmyModel : BaseModel
    {
        public int id;
        public int MaxHp;
        public int Atk;
        public int ShootSpeed;

        public override object Key()
        {
            return id;
        }
    }
}