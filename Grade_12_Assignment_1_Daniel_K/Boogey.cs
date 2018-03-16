using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_12_Assignment_1_Daniel_K
{
    class Boogey : BagMonster
    {
        
        //Boogeyman variables 
        protected const int BOOGEYMAN_HP = 100, //Health
            BOOGEYMAN_ATTACK = 100, //Attack
            BOOGEYMAN_DEFENSE = 100, //defense
            BOOGEYMAN_MAGIC = 100; //Magic points
            
        protected const double BOOGEYMAN_CHANCE = 0.25; //catch chance
        protected const string BOOGEYMAN_TYPE = "Boogey"; //type of bagmonster 
        
        public Boogey() : this("")
        {

        }
        /// <summary>
        /// //Constructs a Boogeyman and applies stat values
        /// </summary>
        /// <param name="name">User made name</param>
        public Boogey(string name)
        {
            TotalHealth = BOOGEYMAN_HP;
            CurrentHealth = BOOGEYMAN_HP;
            AttackPoints = BOOGEYMAN_ATTACK;
            DefensePoints = BOOGEYMAN_DEFENSE;
            MagicPoints = BOOGEYMAN_MAGIC;
            CatchChance = BOOGEYMAN_CHANCE;
            Type = BOOGEYMAN_TYPE;
            ExperiencePoints = GLOBAL_INIT_XP;
            Name = name;
            IsAlive = true;
            IsWild = false;
            

        }
        public override void Attack( BagMonster enemy)
        {
            if (enemy is BoogeyChild)
            {
                
                enemy.CurrentHealth -= 35;//35 damage to boogey boys
            }
            else { enemy.CurrentHealth -= 25; }//25 to everything else

            
        
        }
    
        public override void MagicAttack( BagMonster enemy)//magic attack
        {
            enemy.CurrentHealth -= 50;
            MagicPoints -= 10;
            

        }
        public override void Heal()
        {
            CurrentHealth += 25;
            MagicPoints -= 10;
            
        }
        public override void MagicBoost()
        {
            throw new NotImplementedException();
        }
        

    }


}
