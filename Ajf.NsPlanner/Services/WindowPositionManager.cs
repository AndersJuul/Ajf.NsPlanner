using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ajf.NsPlanner.UI.Models;
using Newtonsoft.Json;

namespace Ajf.NsPlanner.UI.Services
{
    public static class WindowPositionManager
    {
        public static string PathToFileWithWindowstatesJson
        {
            get
            {
                var nsFolderPath = Globals.NsFolderPath();
                return Path.Combine(nsFolderPath, @"windowstates.json");
            }
        } 

        private static List<WindowPositionState> _windowPositionStates;

        private static List<WindowPositionState> WindowPositionStates
        {
            get
            {
                if (_windowPositionStates == null)
                {
                    if (File.Exists(PathToFileWithWindowstatesJson))
                    {
                        _windowPositionStates = JsonConvert
                            .DeserializeObject<List<WindowPositionState>>(
                                File.ReadAllText(PathToFileWithWindowstatesJson)
                                );
                    }
                    else
                    {
                        _windowPositionStates = new List<WindowPositionState>();
                    }
                }

                return _windowPositionStates;
            }
        }

        public static PositionEtc Get(string name)
        {
            var windowPositionState = WindowPositionStates.SingleOrDefault(x => x.Name == name);
            if (windowPositionState == null)
                return new PositionEtc
                {
                    Left = 0,
                    Top = 0,
                    Height = 500,
                    Width = 500
                };

            return windowPositionState.PositionEtc;
        }

        public static void Set(string name, PositionEtc positionEtc)
        {
            var windowPositionState = WindowPositionStates.SingleOrDefault(x => x.Name == name);
            if (windowPositionState == null)
            {
                windowPositionState = new WindowPositionState {Name = name};
                WindowPositionStates.Add(windowPositionState);
            }

            windowPositionState.PositionEtc = positionEtc;

            Save();
        }

        private static void Save()
        {
            File.WriteAllText(PathToFileWithWindowstatesJson, JsonConvert.SerializeObject(WindowPositionStates));
        }
    }
}