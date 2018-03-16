using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grade_12_Assignment_1_Daniel_K
{
    abstract class BagMonster
    {
        protected const int GLOBAL_INIT_XP = 0;//initial XP for all monsters

        protected int _totalHealth;//total health of a monster
        /// <summary>
        /// gets or sets the total health of a monster
        /// </summary>
        public int TotalHealth
        {
            get { return _totalHealth; }
            internal set
            {
                if (value > 0)//no negative or zero values
                { _totalHealth = value; }
            }
        }
        protected int _currentHealth;//The Curent health of a monster
        /// <summary>
        /// Gets or sets The Curent health of a monster
        /// </summary>
        public int CurrentHealth
        {
            get { return _currentHealth; }
            internal set
            {
                if (value >= 0)//no negative values
                {
                    if (value > TotalHealth)
                    {
                        _currentHealth = TotalHealth;//sets the current health to total to prevent overhealing
                    }
                    else
                    {
                        _currentHealth = value;
                    }

                }
                else
                {
                    _currentHealth = 0;//set to zero when over killed
                }
                
            }
        }
        protected double _attackPoints;//The damage a monster does
        /// <summary>
        /// Gets or sets The damage a monster does
        /// </summary>
        public double AttackPoints
        {
            get { return _attackPoints; }
            internal set 
            { 
                if (value >= 0) { _attackPoints = value; } //no negative values
            }
        }
        protected double _defensePoints;//The amount of defense a monster can muster
        /// <summary>
        /// Gets or sets The amount of defense a monster can muster
        /// </summary>
        public double DefensePoints
        {
            get { return _defensePoints; }
            internal set { if (value >= 0) { _defensePoints = value; } }//no negative values
        }
        protected int _magicPoints;//The amount of magic points a monster has
        /// <summary>
        /// Gets or sets The amount of magic points a monster has
        /// </summary>
        public int MagicPoints
        {
            get { return _magicPoints; }
            internal set { if (value >= 0) { _magicPoints = value; } }//no negative values
        }
        protected int _experiencePoints;//The monster's experience level
        /// <summary>
        /// Gets or sets The amount of magic points a monster has
        /// </summary>
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            internal set { if (value >= 0) { _experiencePoints = value; } }//no negative values
        }
        protected string _type;//What type the monster is
        /// <summary>
        /// Gets or sets the type the monster is
        /// </summary>
        public string Type
        {
            get { return _type; }
            internal set { _type = value; }
        }
        protected bool _isWild;//Whether the monster is owned or wild
        /// <summary>
        /// gets or sets Whether the monster is owned or wild
        /// </summary>
        public bool IsWild
        {
            get { return _isWild; }
            internal set { _isWild = value; }
        }
        protected double _catchChance;//Chance to catch a monster
        /// <summary>
        /// gets or sets the Chance to catch a monster
        /// </summary>
        public double CatchChance
        {
            get { return _catchChance; }
            internal set { if (value >= 0) { _catchChance = value; } }//no negative values
        }
        protected bool _isAlive;//Whether or not the monster is alive
        /// <summary>
        /// gets or sets Whether or not the monster is alive
        /// </summary>
        public bool IsAlive
        {
            get { return _isAlive; }
            internal set { _isAlive = value; }
        }
        protected string _name; //personal name of bagmonster
        /// <summary>
        /// gets or sets the personal name of player's bagmonster
        /// </summary>
        public string Name
        {
            get { return _name; }
            internal set { if (value == "") { _name = "N/a"; } else { _name = value; } } 
        }


        public abstract void Attack( BagMonster enemy);//attack action signature
        public abstract void MagicAttack(BagMonster enemy);//magic attack sig.
        public abstract void Heal();//healing sig.
        public abstract void MagicBoost();

        
        
        
        
            
        
    }
}
