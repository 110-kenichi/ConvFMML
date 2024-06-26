﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvFMML.Data.MML.Command.MUCOM88
{
    public class MUCOM88Note : Note
    {
        public MUCOM88Note(int octave, string name, List<int> length, MMLCommandRelation relation) : base(octave, name, length, relation) { }

        protected override string GenerateString(Settings settings, SoundModule module)
        {
            int len = Length[0];
            string str = string.Empty;
            Settings.NoteRest nrSettings = settings.noteRest;

            if (nrSettings.TieStyle == 0 ||
                (!CommandRelation.HasFlag(MMLCommandRelation.TieBefore) || CommandRelation.HasFlag(MMLCommandRelation.PrevControl)))
            {
                str += Name;
            }
            if(len != (int)nrSettings.DefaultLength)
                str += len.ToString();

            int dotlen = 0;
            for (int i = 1; i < Length.Count; i++)
            {
                if (len * 2 == Length[i] && nrSettings.DotEnable && dotlen < 1)
                {
                    str += ".";
                    dotlen++;
                }
                else
                {
                    if (nrSettings.TieStyle == 0)       // Tie and Name
                    {
                        if(Length[i] != (int)nrSettings.DefaultLength)
                            str = str + "&" + Name + Length[i];
                        else
                            str = str + "&" + Name;
                    }
                    else       // Tie only
                    {
                        str = str + "^" + Length[i];
                    }
                    dotlen = 0;
                }
                len = Length[i];
            }

            if (CommandRelation.HasFlag(MMLCommandRelation.TieAfter))
            {
                if (nrSettings.TieStyle == 1 && !CommandRelation.HasFlag(MMLCommandRelation.NextControl))
                {
                    str += "^";
                }
                else
                {
                    str += "&";
                }
            }

            return str;
        }
    }
}
