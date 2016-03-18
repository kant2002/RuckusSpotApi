using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruckus.Spot.PushApi
{
    [ProtoContract]
    public class LocationMessages
    {
        [ProtoMember(1)]
        public LocationMessage[] Messages;
    }
}
