﻿using System.Collections.Generic;
using System.IO;
using RelaxedWinnerDll.Data;
using LeagueSharp.Common;

namespace RelaxedWinner
{
    public class Files
    {
        private const string FileName = "Messages.xml";
        public static string Folder = Config.LeagueSharpDirectory + @"\RelaxedWinner\";

        internal static void GetData()
        {
            if (!File.Exists(FileName))
            {
                RelaxedWinnerDll.RelaxedWinner.MessageData.GameEnd = new List<Information>
                {
                    new Information { Message = "gg" },
                    new Information { Message = "GG" },
                    new Information { Message = "gg all" },
                    new Information { Message = "GG all" },
                    new Information { Message = "good game all" },
                    new Information { Message = "gg wp" }
                };
                RelaxedWinnerDll.RelaxedWinner.MessageData.GameStart = new List<Information>
                {
                    new Information { Message = "gl & hf" },
                    new Information { Message = "GL HF" },
                    new Information { Message = "GL && HF" }
                };
                Save();
            }
            else
            {
                RelaxedWinnerDll.RelaxedWinner.MessageData =
                    (Messages)
                        SerializeXml.DeserializeFromXml(
                            Path.Combine(Folder, FileName), RelaxedWinnerDll.RelaxedWinner.MessageData.GetType());
            }
        }

        internal static void CreateFolder()
        {
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
        }

        internal static void Save()
        {
            SerializeXml.SerializeToXml(RelaxedWinnerDll.RelaxedWinner.MessageData, Path.Combine(Folder, FileName));
        }
    }
}