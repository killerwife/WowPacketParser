using System;

namespace WowPacketParser.Store.Objects.Data
{
    public class CreatureStatsAndResists
    {
        public UInt32 Entry { get; set; }
        public UInt32 Level { get; set; }
        public UInt32 Class { get; set; }
        public Int32[] Stats { get; set; } = new Int32[5];
        public Int32[] Resistances { get; set; } = new Int32[7];
        public Int32 AttackPower { get; set; }
        public Int32 RangedAttackPower { get; set; }

        public string ToString(string creatureName)
        {
            string output = "";
            output += "Entry: " + Entry + " (" + creatureName + ")\n";
            output += "Level: " + Level + " Class: " + Class + "\n";
            output += "Stats:" + " Strength " + Stats[0] + " Agility " + Stats[1] + " Stamina " + Stats[2] + " Intellect " + Stats[3] + " Spirit " + Stats[4] + "\n";
            output += "Resistances:" + " Armor " + Resistances[0] + " Holy " + Resistances[1] + " Fire " + Resistances[2] + " Nature " + Resistances[3] + " Frost " + Resistances[4] + " Shadow " + Resistances[5] + " Arcane " + Resistances[6] + "\n";
            output += "AttackPower: " + AttackPower + "\n";
            output += "RangedAttackPower: " + RangedAttackPower + "\n";
            return output;
        }
    }
}
