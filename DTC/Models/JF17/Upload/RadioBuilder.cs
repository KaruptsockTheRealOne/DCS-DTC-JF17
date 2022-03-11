﻿using DTC.Models.DCS;
using DTC.Models.JF17.Radios;
using System.Linq;
using System.Text;

namespace DTC.Models.JF17.Upload
{
    class RadioBuilder : BaseBuilder
    {
        private JF17Configuration _cfg;

        public RadioBuilder(JF17Configuration cfg, JF17Commands JF17, StringBuilder sb) : base(JF17, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));
            if (_cfg.Radios.COM1.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("COM1", _cfg.Radios.COM1, ufc);
            AppendCommand(ufc.GetCommand("RTN"));
            if (_cfg.Radios.COM2.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("COM2", _cfg.Radios.COM2, ufc);
        }

        private void BuildRadio(string radioCmd, Radio radio, Device ufc)
        {
            AppendCommand(ufc.GetCommand(radioCmd));
            AppendCommand(ufc.GetCommand("DOWN"));
            AppendCommand(ufc.GetCommand("DOWN"));

            for (var i = 0; i < radio.Channels.Length; i++)
            {
                var ch = radio.Channels[i];
                if (!ch.ToBeUpdated)
                    continue;
                AppendCommand(BuildDigits(ufc, ch.Channel.ToString()));
                AppendCommand(ufc.GetCommand("ENTR"));
                AppendCommand(ufc.GetCommand("DOWN"));

                var freq = ch.GetFrequency().ToString();
                freq = DeleteLeadingZeros(RemoveSeparators(freq));

                AppendCommand(BuildDigits(ufc, freq));
                AppendCommand(ufc.GetCommand("ENTR"));
                AppendCommand(ufc.GetCommand("UP"));
            }

            AppendCommand(ufc.GetCommand("1"));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, radio.SelectedChannel.Channel.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("RTN"));
        }
    }
}
