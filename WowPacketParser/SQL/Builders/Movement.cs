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

            string output = "SET @MOVID = 0;";
            int counter = 0;
            if (Settings.TargetedProject == TargetedProject.Cmangos)
            {
                string nodeSql = "INSERT INTO waypoint_path (PathId, Point, PositionX, PositionY, PositionZ, Orientation, WaitTime, ScriptId, Comment) VALUES\n";
                foreach (var data in Storage.CreatureMovement)
                {
                    var creatureMovement = data.Item1;
                    if (creatureMovement.Waypoints.Count == 0)
                        continue;

                    string commentInformation = $"GUID: {creatureMovement.GUID.ToString()} MovementType: {creatureMovement.Type}";
                    output += "-- " + commentInformation + "\n";
                    output += nodeSql;

                    int pointId = 1;
                    foreach (var node in creatureMovement.Waypoints)
                    {
                        bool finalP = creatureMovement.Waypoints.Count == pointId;
                        float ori = finalP ? (creatureMovement.FinalOrientation != null ? creatureMovement.FinalOrientation.Value : 100f) : 100f;
                        output += $"('@MOVID + {counter}', '{pointId}', '{node.Position.X}', '{node.Position.Y}', '{node.Position.Z}', '{ori}', '0', '0', NULL)";
                        
                        if (!finalP)
                            output += ",\n";
                        else
                            output += ";\n";
                        
                        ++counter;
                    }
                }
            }

            return output;
        }
    }
}
