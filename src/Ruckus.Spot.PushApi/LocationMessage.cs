using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruckus.Spot.PushApi
{
    [ProtoContract]
    public class LocationMessage
    {
        [ProtoMember(1)]
        public string venue_id;

        [ProtoMember(2)]
        public string mac;

        [ProtoMember(3)]
        public float x;

        [ProtoMember(4)]
        public float y;

        [ProtoMember(5)]
        public uint floor_number;

        [ProtoMember(6)]
        public uint timestamp;
    }
}
