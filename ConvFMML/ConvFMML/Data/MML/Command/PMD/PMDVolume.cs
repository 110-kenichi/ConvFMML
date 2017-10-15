﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvFMML.Data.MML.Command.PMD
{
    public class PMDVolume : Volume
    {
        public PMDVolume(int value, MMLCommandRelation relation) : base(value, relation) { }

        protected override string GenerateString(Settings settings, SoundModule module)
        {
            string sign;
            int newValue;
            Settings.ControlCommand.Volume volumeSettings = settings.controlCommand.volume;

            if (volumeSettings.CommandPMD == 0)
            {
                sign = "v";
                double temp;
                if (module == SoundModule.SSG)
                {
                    temp = Value * 15.0 / 127.0;
                }
                else
                {
                    temp = Value * 16.0 / 127.0;
                }
                newValue = (int)Math.Round(temp, MidpointRounding.AwayFromZero);
            }
            else
            {
                sign = "V";
                if (module == SoundModule.SSG)
                {
                    double temp = Value * 15.0 / 127.0;
                    newValue = (int)Math.Round(temp, MidpointRounding.AwayFromZero);
                }
                else
                {
                    newValue = Value;
                }
            }

            return sign + newValue;
        }
    }
}
