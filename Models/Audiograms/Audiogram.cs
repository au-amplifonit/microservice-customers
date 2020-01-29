using Fox.Microservices.Customers.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models.Audiograms
{
    public class Audiogram: AudiogramBase
    {
        [JsonProperty(Order = 0)]
        public short HiConditionCode { get; set; }

        [JsonProperty(Order = 0)]
        public short Frame { get; set; }

        [JsonProperty(Order = 2)]
        public AudiogramFrequencyData[] AudiogramData { get; set; }

        public Audiogram()
        {

        }

        public Audiogram(CU_B_AUDIOGRAM Entity) : base(Entity)
        {
            HiConditionCode = Entity.HICONDITION_CODE;
            Frame = Entity.FRAME;
            List<AudiogramFrequencyData> FreqData = new List<AudiogramFrequencyData>();
            for(int Index = 1; Index <= 15; Index++)
            {
                AudiogramFrequencyData Data;
                if (CreateAudiogramFrequencyData(Entity, Index, out Data))
                    FreqData.Add(Data);
            }
            AudiogramData = FreqData.ToArray();
        }

        bool CreateAudiogramFrequencyData(CU_B_AUDIOGRAM Entity, int AFrequencyNumber, out AudiogramFrequencyData AData)
        {
            bool Result = false;
            AData = null;
            int? Frequency = (int?)Entity.GetType().GetProperty(string.Format("FREQ_{0}", AFrequencyNumber)).GetValue(Entity);
            Result = Frequency.HasValue;
            if (Result)
            {
                AData = new AudiogramFrequencyData();
                AData.Frequency = Frequency.Value;
                AData.Value = (double?)Entity.GetType().GetProperty(string.Format("VALUE_{0}", AFrequencyNumber)).GetValue(Entity);
                AData.Mask = (string)Entity.GetType().GetProperty(string.Format("FLGMASK_{0}", AFrequencyNumber)).GetValue(Entity) == "Y";
                AData.NoAnswer = (string)Entity.GetType().GetProperty(string.Format("FLGNOANSWER_{0}", AFrequencyNumber)).GetValue(Entity) == "Y";
            }
            return Result;
        }
    }

    public class AudiogramFrequencyData
    {
        public int Frequency { get; set; }

        public double? Value { get; set; }

        public bool Mask { get; set; }

        public bool NoAnswer { get; set; }
    }
}
