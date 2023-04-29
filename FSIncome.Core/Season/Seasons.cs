using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Season
{
    public class Seasons
    {
        private int _day { get; set; }
        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }
        private int _currentSeason { get; set; }
        public int CurrentSeason
        {
            get { return _currentSeason; }
            set { _currentSeason = value; }
        }
        private int _currentSeasonStage { get; set; }
        
        public int CurrentSeasonStage
        {
            get { return _currentSeasonStage; }
            set { _currentSeasonStage = value; }
        }

        private int _seasonDays { get; set; }
        public int SeasonDays
        {
            get
            {
                return _seasonDays;
            }
            set
            {
                _seasonDays = value;
            }
        }

        //variables
        int _stageIndex { get; set; } = 1; //beg 1 for skipping 0 
        private List<int> stagePoints { get; set; } = new List<int>();

        public Seasons(int profileNumber) 
        {
            LoadSeasonsData(profileNumber);
        }

        public void NextDayClick(int profileNr)
        {
            if (_day == _seasonDays && _currentSeason == 3)
            {
                _day = 0;
                _currentSeason = 0;
                _stageIndex = 1;
                _currentSeasonStage = 0;
            }
            else if (_day == _seasonDays)
            {
                _day = 0;
                _stageIndex = 1;
                _currentSeason++;
                _currentSeasonStage = 0;
            }
            else if (stagePoints[_stageIndex] == _day)
            {
                _stageIndex++;
                _currentSeasonStage++;
                _day++;
            }
            else
            {
                _day++;
            }

            var systemFile = FileClass.ReadSystemFile();
            systemFile.seasonsTag.seasonProfiles[profileNr].seasonDay = _day;
            systemFile.seasonsTag.seasonProfiles[profileNr].seasonName = _currentSeason;
            systemFile.seasonsTag.seasonProfiles[profileNr].seasonStage = _currentSeasonStage;
            FileClass.SaveSystemFile(systemFile);
        }

        public void LoadSeasonsData(int profileNumber)
        {
            var systemFile = FileClass.ReadSystemFile();
            _day = systemFile.seasonsTag.seasonProfiles[profileNumber].seasonDay;
            _currentSeason = systemFile.seasonsTag.seasonProfiles[profileNumber].seasonName;
            _currentSeasonStage = systemFile.seasonsTag.seasonProfiles[profileNumber].seasonStage;

            var settingsFile = FileClass.ReadSettingsFile();
            _seasonDays = settingsFile.seasonDays;

            for (int i = 0; i < _seasonDays; i++)
            {
                if (i % (_seasonDays / 3) == 0)
                {
                    stagePoints.Add(i);
                }
            }
            stagePoints.Add(_seasonDays + 1);
        }
    }
}
