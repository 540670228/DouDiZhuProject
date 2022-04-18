using System;
using UnityEngine;

namespace ET
{
    [ActorMessageHandler]
    public class M2M_UnitLTransferRequestHandler : AMActorRpcHandler<Scene, M2M_UnitLTransferRequest, M2M_UnitLTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitLTransferRequest request, M2M_UnitLTransferResponse response, Action reply)
        {
            await ETTask.CompletedTask;
            UnitLComponent unitLComponent = scene.GetComponent<UnitLComponent>();
            UnitL unitL = request.UnitL;
            UnitL last = unitLComponent.GetChild<UnitL>(unitL.Id);
            if(last!=null) last.Dispose();
            
            unitLComponent.AddChild(unitL);
            unitLComponent.Add(unitL);

            foreach (Entity entity in request.Entitys)
            {
                unitL.AddComponent(entity);
            }
            
			
            unitL.AddComponent<MailBoxComponent>();
			
            // 通知客户端创建My Unit
            M2C_CreateUnitL m2CCreateUnitL = new M2C_CreateUnitL();
            m2CCreateUnitL.UnitLInfo = UnitLHelper.CreateUnitLInfo(unitL);
            MessageHelper.SendToClient(unitL, m2CCreateUnitL);
            

            response.NewInstanceId = unitL.InstanceId;
			
            reply();
        }
    }
}