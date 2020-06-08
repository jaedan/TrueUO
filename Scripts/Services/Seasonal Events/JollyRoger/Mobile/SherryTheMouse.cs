using System.Collections.Generic;
using Server.Engines.Quests;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Engines.Fellowship
{
    public class SherryLute : Item
    {
        [Constructable]
        public SherryLute()
            : base(0xEB3)
        {
            Weight = 0.0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 1))
            {
                from.SendLocalizedMessage(500446); // That is too far away.
            }
            else
            {
                from.PlaySound(0x4C);
                PrivateOverheadMessage(MessageType.Regular, 0x47E, 1159341, from.NetState, "G");
            }
        }

        public SherryLute(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SherryTheMouse : BaseQuester
    {
        public static SherryTheMouse InstanceTram { get; set; }
        public static SherryTheMouse InstanceFel { get; set; }
        
        [Constructable]
        public SherryTheMouse()
            : base("the Mouse")
        {
        }

        public override void InitBody()
        {
            base.InitBody();

            Name = "Sherry";

            Body = 0xEE;
        }

        public override void OnTalk(PlayerMobile player, bool contextMenu)
        {
        }

        public override bool CanTalkTo(PlayerMobile to)
        {
            return false;
        }

        public override void OnDoubleClick(Mobile from)
        {
            Gump g = new Gump(100, 100);
            g.AddBackground(0, 0, 454, 640, 0x24A4);
            g.AddImage(60, 40, 0x6D2);
            g.AddHtmlLocalized(27, 389, 398, 18, 1114513, "#115938", 0xC63, false, false); // <DIV ALIGN=CENTER>~1_TOKEN~</DIV>
            g.AddHtmlLocalized(27, 416, 398, 174, 1159386, 0xC63, false, true); // You have found yourself here, or have I made it so you find yourself here? *grins* Alas, here you are! <br><br>Virtue is being drained from your world at the hands of the Fellowship under the guise of their altruistic intent. Do not be fooled, their objective is nefarious and their presence in Britannia is a pox upon our shared devotion to the Virtues. <br><br>The Fellowship has been successful in destroying the Runes of Virtue and the encouraging greed in those coveting Fellowship Treasure. This is fueling the destruction of Shrines across Britannia. To combat this trend, I reached deep inside the timeline and placed fragments of the Runes of Virtue in treasure chests hidden throughout the realm. With these fragments we can begin to restore the Shrines. Place these mysterious fragments at Shrines across Britannia to lure the armies of the Fellowship from hiding. <br><br>If you best eight of these armies at a single shrine you have restored the most fragments, your devotion to Virtue will be rewarded with the Tabard of Virtue. This tabard will reflect the Virtue to which you have restored the most fragments. A corresponding title will also be bestowed upon you. <br><br>For those who are truly devout and summon the Courage to best three of the armies at each Shrine, they will be awarded the Cloak of the Virtuous - a truly auspicious honor! <br><br>When you have completed your quest visit the Ankh behind me to claim your Tabard of Virtue. To claim the Cloak of the Virtuous approach each representation of the Virtues surrounding me. When you are true to each, the Cloak of the Virtuous shall be yours!

            from.SendGump(g);
        }

        public SherryTheMouse(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (Map == Map.Trammel)
            {
                InstanceTram = this;
            }

            if (Map == Map.Felucca)
            {
                InstanceFel = this;
            }
        }
    }
}
