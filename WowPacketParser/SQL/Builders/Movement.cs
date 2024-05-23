using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Store;

namespace WowPacketParser.SQL.Builders
{
    [BuilderClass]
    public static class Movement
    {

        [BuilderMethod]
        public static string MovementData()
        {
            if (Storage.CreatureMovement.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_movement))
                return string.Empty;

            string result = "";
            return result;
        }
    }
}
