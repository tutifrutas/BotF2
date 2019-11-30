﻿using Supremacy.Collections;
using Supremacy.Economy;
using Supremacy.Entities;
using Supremacy.Game;
using Supremacy.Universe;
using Supremacy.Utility;
using System;


namespace Supremacy.Intelligence
{
    public static class IntelHelper
    {
        private static Civilization _newTargetCiv;
        private static Civilization _newSpyCiv;
        private static UniverseObjectList<Colony> _newSpiedColonies;

        public static UniverseObjectList<Colony> NewSpiedColonies
        {
            get { return _newSpiedColonies; }
        }
        public static Civilization NewSpyCiv
        {
            get { return _newSpyCiv; }
        }
        public static Civilization NewTargetCiv
        {
            get { return _newTargetCiv; }
        }

        public static void SendXSpiedY(Civilization spyCiv, Civilization spiedCiv, UniverseObjectList<Colony> colonies)
        {
            if (spyCiv == null)
                throw new ArgumentNullException("spyCiv");
            if (spiedCiv == null)
                throw new ArgumentNullException("spiedCiv");

            _newSpyCiv = spyCiv;
            _newTargetCiv = spiedCiv;
            _newSpiedColonies = colonies;
        }
        #region Espionage Methods
        public static void SabotageEnergy(Colony colony, Civilization civ)
        {
            var system = colony.System;
            var attackedCiv = GameContext.Current.CivilizationManagers[colony.System.Owner];
            var spyEmpire = IntelHelper.NewSpyCiv;
            int ratio = -1;
            if (spyEmpire == null)
                return;

            if (colony == null)
                return;

            bool ownedByPlayer = (colony.OwnerID == spyEmpire.CivID);
            if (ownedByPlayer)
                return;

            int defenseIntelligence = attackedCiv.TotalIntelligenceProduction + 1;  // TotalIntelligence of attacked civ
            if (defenseIntelligence - 1 < 0.1)
                defenseIntelligence = 2;

            int attackingIntelligence = GameContext.Current.CivilizationManagers[spyEmpire].TotalIntelligenceProduction + 1;  // TotalIntelligence of attacked civ
            if (attackingIntelligence - 1 < 0.1)  
                attackingIntelligence = 1;
                    
                    attackingIntelligence = 100 * attackingIntelligence;// just for increase attacking Intelligence

            ratio = attackingIntelligence / defenseIntelligence;
            if (ratio < 2)
                ratio = 1;   // we start with sabotage with ratio more than one, not before

            //GameLog.Core.Intel.DebugFormat("Sabotage Energy to {0}: defense={1}, attacking={2}, ratio={3}",
            //    system.Name, defenseIntelligence, attackingIntelligence, ratio);

            GameLog.Core.Intel.DebugFormat("owner= {0}, system= {1} is SABOTAGED by civ= {2} (Intelligence: defense={3}, attack={4}, ratio={5})",
                system.Owner, system.Name, civ.Name, defenseIntelligence, attackingIntelligence, ratio);


            GameLog.Core.Intel.DebugFormat("Owner= {0}, system= {1} at {2} (sabotaged): Energy=? out of facilities={3}, in total={4}",
                system.Owner, system.Name, system.Location,
                //colony.GetEnergyUsage(),
                system.Colony.GetActiveFacilities(ProductionCategory.Energy),
                system.Colony.GetTotalFacilities(ProductionCategory.Energy));
            GameLog.Core.Intel.DebugFormat("Sabotage Energy to {0}: TotalEnergyFacilities before={1}",
                system.Name, colony.GetTotalFacilities(ProductionCategory.Energy));

            //Effect of sabatoge
            int removeEnergyFacilities = 0;                  

            //if ratio > 1 than remove one more  EnergyFacility
            if (ratio > 1 && colony.GetTotalFacilities(ProductionCategory.Energy) > 1)// Energy: remaining everything down to 1, for ratio: first value > 1 is 2, so ratio must be 2 or more
            {
                removeEnergyFacilities = 1;
                colony.RemoveFacilities(ProductionCategory.Energy, 1);
            }

            //if ratio > 2 than remove one more  EnergyFacility
            if (ratio > 2 && system.Colony.GetTotalFacilities(ProductionCategory.Energy) > 2)// Energy: remaining everything down to 1, for ratio: first value > 1 is 2, so ratio must be 2 or more
            {
                removeEnergyFacilities = 3;  //  2 and one from before
                system.Colony.RemoveFacilities(ProductionCategory.Energy, 2);
            }

            // if ratio > 3 than remove one more  EnergyFacility
            if (ratio > 3 && system.Colony.GetTotalFacilities(ProductionCategory.Energy) > 3)// Energy: remaining everything down to 1, for ratio: first value > 1 is 2, so ratio must be 2 or more
            {
                removeEnergyFacilities = 6;  //   3 and 3 from before = 6 in total , max 6 should be enough for one sabotage ship
                system.Colony.RemoveFacilities(ProductionCategory.Energy, 3);
            }


            GameContext.Current.CivilizationManagers[system.Owner].TotalIntelligenceDefenseAccumulated -= defenseIntelligence / 2;
            GameContext.Current.CivilizationManagers[spyEmpire].TotalIntelligenceAttackingAccumulated -= attackingIntelligence;

            GameLog.Core.Intel.DebugFormat("Sabotage Energy at {0}: TotalEnergyFacilities after={1}", system.Name, colony.GetTotalFacilities(ProductionCategory.Energy));
            attackedCiv.SitRepEntries.Add(new NewSabotageSitRepEntry(civ, system.Colony, removeEnergyFacilities, system.Colony.GetTotalFacilities(ProductionCategory.Energy)));

        }

        public static void SabotageFood(Colony colony, Civilization civ)
        {
            var system = colony.System;
            var attackedCiv = GameContext.Current.CivilizationManagers[colony.System.Owner];
            var spyEmpire = IntelHelper.NewSpyCiv;
            int ratio = -1;
            if (spyEmpire == null)
                return;

            if (colony == null)
                return;

            bool ownedByPlayer = (colony.OwnerID == spyEmpire.CivID);
            if (ownedByPlayer)
                return;

            int defenseIntelligence = attackedCiv.TotalIntelligenceProduction + 1;  // TotalIntelligence of attacked civ
            if (defenseIntelligence - 1 < 0.1)
                defenseIntelligence = 2;

            int attackingIntelligence = GameContext.Current.CivilizationManagers[spyEmpire].TotalIntelligenceProduction + 1;  // TotalIntelligence of attacked civ
            if (attackingIntelligence - 1 < 0.1)
                attackingIntelligence = 1;

            attackingIntelligence = 100 * attackingIntelligence;// just for increase attacking Intelligence

            ratio = attackingIntelligence / defenseIntelligence;
            if (ratio < 2)
                ratio = 1;   // we start with sabotage with ratio more than one, not before

            GameLog.Core.Intel.DebugFormat("owner= {0}, system= {1} is SABOTAGED by civ= {2} (Intelligence: defense={3}, attack={4}, ratio={5})",
                system.Owner, system.Name, civ.Name, defenseIntelligence, attackingIntelligence, ratio);


            GameLog.Core.Intel.DebugFormat("Owner= {0}, system= {1} at {2} (sabotaged): Energy=? out of facilities={3}, in total={4}",
                system.Owner, system.Name, system.Location,
                //colony.GetEnergyUsage(),
                system.Colony.GetActiveFacilities(ProductionCategory.Food),
                system.Colony.GetTotalFacilities(ProductionCategory.Food));
            GameLog.Core.Intel.DebugFormat("Sabotage FOOD to {0}: TotalFoodFacilities before={1}",
                system.Name, colony.GetTotalFacilities(ProductionCategory.Food));

            //Effect of sabatoge
            int removeFoodFacilities = 0;

            //if ratio > 1 than remove one more  EnergyFacility
            if (ratio > 1 && colony.GetTotalFacilities(ProductionCategory.Food) > 1)// Food: remaining everything down to 1, for ratio: first value > 1 is 2, so ratio must be 2 or more
            {
                removeFoodFacilities = 1;
                colony.RemoveFacilities(ProductionCategory.Food, 1);
            }

            //if ratio > 2 than remove one more  FoodFacility
            if (ratio > 2 && system.Colony.GetTotalFacilities(ProductionCategory.Food) > 2)// Food: remaining everything down to 1, for ratio: first value > 1 is 2, so ratio must be 2 or more
            {
                removeFoodFacilities = 3;  //  2 and one from before
                system.Colony.RemoveFacilities(ProductionCategory.Food, 2);
            }

            // if ratio > 3 than remove one more  FoodFacility
            if (ratio > 3 && system.Colony.GetTotalFacilities(ProductionCategory.Food) > 3)// Food: remaining everything down to 1, for ratio: first value > 1 is 2, so ratio must be 2 or more
            {
                removeFoodFacilities = 6;  //   3 and 3 from before = 6 in total , max 6 should be enough for one sabotage ship
                system.Colony.RemoveFacilities(ProductionCategory.Food, 3);
            }

            GameLog.Core.Intel.DebugFormat("Sabotage Food at {0}: TotalFoodFacilities after={1}", system.Name, colony.GetTotalFacilities(ProductionCategory.Food));
            attackedCiv.SitRepEntries.Add(new NewSabotageSitRepEntry(civ, system.Colony, removeFoodFacilities, system.Colony.GetTotalFacilities(ProductionCategory.Food)));

        }

        internal static void StealResearch(Colony colony, Civilization spiedFourCiv)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
