using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_12_Assignment_1_Daniel_K
{
     class Player
    {
        private const int MAX_MONSTERS = 10,//MAximum amount of monsters
            MAX_ACTIONS = 50;//Maximum amount of turns
        
        private int _totalXPGained = 0;//xp gained through monsters
        private int _numBalls = 0;//bagball amount  
        private int _numActions = 0;//actions left
        private string _playerName;//player's name
        private int _monsterCount = 0;//number of monster
        public BagMonster[] bagMonsters = new BagMonster[MAX_MONSTERS];//array of all monsters
        
        /// <summary>
        /// Creates new player type
        /// </summary>
        /// <param name="playerName">Name of the player</param>
        public Player(string playerName)
        {
            _playerName = playerName;
            _numActions = MAX_ACTIONS;

        }
        /// <summary>
        /// Number of bagballs player has
        /// </summary>
        public int NumBalls
        {
            get { return _numBalls; }
            private set { if (value >= 0 && value <= MAX_MONSTERS) { _numBalls = value; } }
        }
        /// <summary>
        /// The number of actions left for the player
        /// </summary>
        public int NumActions
        {
            get { return _numActions; }
            set { if (value >= 0 && value <= MAX_ACTIONS) { _numActions = value; } }
        }
        /// <summary>
        /// The player's name
        /// </summary>
        public string PlayerName
        {
            get { return _playerName; }
            private set { _playerName = value; }
        }
        /// <summary>
        /// number of monster in bag
        /// </summary>
        public int MonsterCount
        {
            get { return _monsterCount; }
            set { if (value >= 0) { _monsterCount = value; } }//no negative values
        }
         public int TotalXPGained
        {
            get { return _totalXPGained; }
            set { _totalXPGained = value; }
        }
        


    }
}
