using System;
using UnityEngine;

namespace ET
{
    public static class UnitLFactory
    {
        public static UnitL Create(Scene scene, long id , RoleInfo roleInfo)
        {
            UnitLComponent unitLComponent = scene.GetComponent<UnitLComponent>();

            UnitL unitL = unitLComponent.AddChildWithId<UnitL,RoleInfo>(id,roleInfo);
            
            unitLComponent.Add(unitL);
            
            return unitL;
        }
    }
}
