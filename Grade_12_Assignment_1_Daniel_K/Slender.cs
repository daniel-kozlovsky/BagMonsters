using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_12_Assignment_1_Daniel_K
{
    class Slender : BagMonster
    {
        //Slender woman variables
        protected const int SLENDERWOMAN_HP = 70, //Health 
            SLENDERWOMAN_ATTACK = 80,   //Attack
            SLENDERWOMAN_DEFENSE = 40, //Defense
            SLENDERWOMAN_MAGIC = 120; //Magic points
            
        protected const double SLENDERWOMAN_CHANCE = 0.1; //catch chance
        protected const string SLENDERWOMAN_TYPE = "Slender"; //type of bagmonster
        
        public Slender()
            :this("")
        {

        }
        /// <summary>
        /// //Constructs a SlenderWoman and applies stat values
        /// </summary>
        /// <param name="name">User made name</param>
        public Slender(string name)
        {
            Name = name;
            TotalHealth = SLENDERWOMAN_HP;
            CurrentHealth = SLENDERWOMAN_HP;
            AttackPoints = SLENDERWOMAN_ATTACK;
            DefensePoints = SLENDERWOMAN_DEFENSE;
            MagicPoints = SLENDERWOMAN_MAGIC;
            CatchChance = SLENDERWOMAN_CHANCE;
            Type = SLENDERWOMAN_TYPE;
            ExperiencePoints = GLOBAL_INIT_XP;
            IsAlive = true;
            IsWild = false;

        }
        public override void Attack(BagMonster enemy)
        {
            double i = (AttackPoints/enemy.DefensePoints);
            i *= 20;
            enemy.CurrentHealth -= (int)i;

        }
        public override void MagicAttack(BagMonster enemy)
        {
            MagicPoints -= 5;
            enemy.CurrentHealth -= 50;
        }

        public override void MagicBoost()
        {
            MagicPoints += 20;
        }
        public override void Heal()
        {
            throw new NotImplementedException();
        }
    }
}
