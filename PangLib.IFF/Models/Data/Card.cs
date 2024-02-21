using PangLib.IFF.Models.General;
using PangLib.IFF.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct Card.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Card : IFFCommon
    {
        public byte Rarity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort AccuracySlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public ushort Effect { get; set; }
        public ushort EffectValue { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture3 { get; set; }
        public ushort EffectTime { get; set; }
        public ushort Volumn { get; set; }
        public UInt32 Position { get; set; }
        public uint flag1 { get; set; }     // !@flag que guarda alguns valores de de N, R, SR, SC e etc
        public uint flag2 { get; set; }     // flag que guarda alguns valores de de N, R, SR, SC e etc

        public bool IsCardPack()
        {
            switch (ID)
            {
                case 2088763415:
                case 2092957696:
                case 2092957697:
                case 2092957698:
                case 2092957699:
                case 2092957702:
                case 2092957700:

                case 2092957701:

                case 2092957703:

                case 2092957704:

                case 2092957705:
                case 2092957706:
                case 2097152000:
                case 2097152002:
                case 2097152003:
                case 2092957707:

                case 2092957708:

                case 2092957709:

                case 2092957710:

                case 2092957711:

                case 2092957712:

                case 2092957713:

                case 2092957714:

                case 2092957715:

                case 2092957716:

                case 2092957717:

                case 2092957718:

                case 2092957719:

                case 2092957720:

                case 2092957721:

                case 2092957722:

                case 2092957723:
                case 2092957724:
                    return true;
                default:
                    return false;
            }
        }

        public string GetTypeEffect()
        {
            var s = new string[] {
            "None",
            "Single Use",
            "% Pang 1",
            "% Pang 2 ",
            "% EXP",
            "Test 5",//pode ser yard
                 "Cadie (Super Card)",//pode ser gauge,6
                 "Cadie (Normal 1)",//pode ser Pangya Zone Impact(7
                 "Cadie (SuperRare)",//pode ser Treasure,8
                 "Cadie (Normal 2)",//pode ser Treasure,9
                 "Cadie (Medium)",//pode ser Treasure,10
                "Cadie (high)",
                "Temporary",
            "Sepia Wind [Bonus]",
            "Wind Hill [Bonus]",
            "Pink Wind [Bonus]",
"Blue Moon [Bonus]",
            "Pang Pouch[Bonus Random]",
            "Treasure Point [Bonus]",
                        "Chance Rain [Bonus]",
            "Blue Lagoon [Bonus]",
            "Blue Walter [Bonus]",
            "Shining Sand [Bonus]",
            "Deep Inferno [Bonus]",
            "Silva Cannon [Bonus]",
            "Easten Valley [Bonus]",
            "Lost Seaway [Bonus]",
            "Inventory [Item Slot]",
            "StartingGauge [Bonus]",
            "Ice Inferno [Bonus]",
            "Wiz City [Bonus]",
            "Chance Rain [Bonus]",
            "Spin [Bonus]",
            "Curve [Bonus]",
            "Pangya Impact Zone",
            "Yard [Bonus]",
            "Pangya Combo Gauge [Bonus]",
            "+2 Hole Rain [Bonus]",
                "% Experience",
           "Power [Bonus]",
         "Control Slot [Bonus]" };
            switch (Effect)
            {
                case 0:
                    {
                       return s[Effect];
                    }
                default:
                    break;
            }
            if (Rarity == 2 && flag1 == 2 && flag2 == 1)
            {
                return " -2 Yard [Penality]";
            }
            if (Rarity == 3 && flag1 == 3 && flag2 == 1)
            {
                return " -1 Yard [Penality]";
            }
            if (Rarity == 0 && flag1 == 2 && flag2 == 1)
            {
                return "Control +1";
            }
            if (Rarity == 1 && flag1 == 2 && flag2 == 1)
            {
                return "Control +2";
            }

            return s[1];
        }
    }
    #endregion
}
