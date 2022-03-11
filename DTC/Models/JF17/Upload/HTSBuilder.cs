using DTC.Models.DCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.JF17.Upload
{
    class HTSBuilder : BaseBuilder
    {
        private JF17Configuration _cfg;

        public HTSBuilder(JF17Configuration cfg, JF17Commands JF17, StringBuilder sb) : base(JF17, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));

            AppendCommand(Wait());

            AppendCommand(StartCondition("NOT_IN_AA"));

            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(StartCondition("NOT_IN_AG"));
            //if (_cfg.HTS.ManualTableEnabledToBeUpdated)
                BuildHTSManualTable();



            AppendCommand(EndCondition("NOT_IN_AG"));

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));
            AppendCommand(ufc.GetCommand("SEQ"));

            AppendCommand(EndCondition("NOT_IN_AA"));

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildHTSManualTable()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(Wait());

            AppendCommand(StartCondition("HTS_DED"));

            AppendCommand(ufc.GetCommand("ENTR"));

            for (var i = 0; i < 8; i++)
            {
                if (_cfg.HTS.ManualEmitters.Length > i)
                {
                    AppendCommand(BuildDigits(ufc, _cfg.HTS.ManualEmitters[i].ToString()));
                }
                else
                {
                    AppendCommand(ufc.GetCommand("0"));
                }
                AppendCommand(ufc.GetCommand("ENTR"));
            }

            AppendCommand(EndCondition("HTS_DED"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

    }
}
