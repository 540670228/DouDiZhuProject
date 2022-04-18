using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class ErrorInfoConfigCategory : ProtoObject
    {
        public static ErrorInfoConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, ErrorInfoConfig> dict = new Dictionary<int, ErrorInfoConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<ErrorInfoConfig> list = new List<ErrorInfoConfig>();
		
        public ErrorInfoConfigCategory()
        {
            Instance = this;
        }
		
        public override void EndInit()
        {
            foreach (ErrorInfoConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public ErrorInfoConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ErrorInfoConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ErrorInfoConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ErrorInfoConfig> GetAll()
        {
            return this.dict;
        }

        public ErrorInfoConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class ErrorInfoConfig: ProtoObject, IConfig
	{
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(2)]
		public int Errorcode { get; set; }
		[ProtoMember(3)]
		public string ErrorInfo { get; set; }

	}
}
