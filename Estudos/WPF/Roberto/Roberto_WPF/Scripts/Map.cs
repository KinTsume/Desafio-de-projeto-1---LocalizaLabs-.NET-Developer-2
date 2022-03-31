using System.Collections.Generic;

namespace Roberto_WPF.GameScripts
{
    public class Map
    {
        private List<StaticEntity> SEntityList;
        private List<DynamicEntity> DEntityList;

        public Map()
        {
            SEntityList = new List<StaticEntity>();
            DEntityList = new List<DynamicEntity>();
        }

        public List<StaticEntity> GetStaticList()
        {
            return SEntityList;
        }

        public void AddStatic(StaticEntity entity)
        {
            SEntityList.Add(entity);
        }

        public List<DynamicEntity> GetDynamicList()
        {
            return DEntityList;
        }

        public void AddDynamic(DynamicEntity entity)
        {
            DEntityList.Add(entity);
        }

        public void RemoveFromList()
        {

        }
    }
}