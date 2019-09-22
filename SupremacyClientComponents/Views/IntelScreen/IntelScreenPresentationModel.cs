﻿using System;
using System.Collections.Generic;
using System.Linq;

using Supremacy.Annotations;
using Supremacy.Orbitals;
using Supremacy.Universe;
using Supremacy.Entities;
using System.Windows.Media.Imaging;
using System.IO;
using Supremacy.Resources;
using Supremacy.Diplomacy;
using Supremacy.Client.Context;
using Supremacy.Game;
using Supremacy.Utility;
//using System.Text;
//using System.Threading.Tasks;

namespace Supremacy.Client.Views.IntelScreen
{
    public class IntelScreenPresentationModel : PresentationModelBase
    {
        #region Fields
        private IEnumerable<Ship> _availableShips;
        //private GalaxyScreenInputMode _inputMode;
        //private GalaxyScreenOverviewMode _overviewMode;
        private Sector _selectedSector;
        private Sector _hoveredSector;
        private string _selectedSectorAllegiance;
        private string _selectedSectorInhabitants;
        private Ship _selectedShip;
        private ShipView _selectedShipInTaskForce;
        private IEnumerable<ShipView> _selectedShipsInTaskForce;
        private Ship _selectedShipResolved;
        private FleetViewWrapper _selectedTaskForce;
        private List<FleetViewWrapper> _iSpyShips;
        private TradeRoute _selectedTradeRoute;
        private IEnumerable<FleetViewWrapper> _taskForces;
        private IEnumerable<FleetViewWrapper> _localPlayerTaskForces;
        private IEnumerable<FleetViewWrapper> _otherVisibleTaskForces;
        private IEnumerable<TradeRoute> _tradeRoutes;
        private readonly EmpirePlayerStatusCollection _empirePlayers;
        private StationPresentationModel _selectedSectorStation;
        #endregion

        #region Events
        public event EventHandler AvailableShipsChanged;
        public event EventHandler InputModeChanged;
        public event EventHandler OverviewModeChanged;
        public event EventHandler SelectedSectorAllegianceChanged;
        public event EventHandler SelectedSectorChanged;
        public event EventHandler HoveredSectorChanged;
        public event EventHandler SelectedSectorInhabitantsChanged;
        public event EventHandler SelectedShipChanged;
        public event EventHandler SelectedShipInTaskForceChanged;
        public event EventHandler SelectedShipsInTaskForceChanged;
        public event EventHandler SelectedTaskForceChanged;
        public event EventHandler TaskForcesChanged;
        public event EventHandler LocalPlayerTaskForcesChanged;
        public event EventHandler VisibleTaskForcesChanged;
        public event EventHandler SelectedTradeRouteChanged;
        public event EventHandler TradeRoutesChanged;
        public event EventHandler SelectedSectorStationChanged;
        #endregion

        #region Constructors and Finalizers
        public IntelScreenPresentationModel([NotNull] IAppContext appContext)
            : base(appContext)
        {
            _empirePlayers = new EmpirePlayerStatusCollection();

            _empirePlayers.AddRange(
                from civ in appContext.CurrentGame.Civilizations
                where civ.IsEmpire
                select new EmpirePlayerStatus(appContext, civ)
                {
                    Player = appContext.Players.FirstOrDefault(o => o.EmpireID == civ.CivID)
                }
                );

            _selectedSectorStation = new StationPresentationModel(appContext);
        }
        #endregion

        #region Properties and Indexers
        public IEmpirePlayerStatusCollection EmpirePlayers
        {
            get { return _empirePlayers; }
        }

        public IEnumerable<Ship> AvailableShips
        {
            get { return _availableShips; }
            set
            {
                if (Equals(_availableShips, value))
                    return;
                _availableShips = value;
                OnAvailableShipsChanged();
            }
        }

        //public GalaxyScreenInputMode InputMode
        //{
        //    get { return _inputMode; }
        //    set
        //    {
        //        if (Equals(_inputMode, value))
        //            return;
        //        _inputMode = value;
        //        OnInputModeChanged();
        //    }
        //}

        //public GalaxyScreenOverviewMode OverviewMode
        //{
        //    get { return _overviewMode; }
        //    set
        //    {
        //        if (Equals(_overviewMode, value))
        //            return;
        //        _overviewMode = value;
        //        OnOverviewModeChanged();
        //    }
        //}

        public Sector SelectedSector
        {
            get { return _selectedSector; }
            set
            {
                if (Equals(_selectedSector, value))
                    return;
                _selectedSector = value;
                OnSelectedSectorChanged();

                _selectedSectorStation.Sector = _selectedSector;
                OnSelectedSectorStationChanged();
            }
        }

        public StationPresentationModel SelectedSectorStation
        {
            get { return _selectedSectorStation; }
        }

        public Sector HoveredSector
        {
            get { return _hoveredSector; }
            set
            {
                if (Equals(_hoveredSector, value))
                    return;
                _hoveredSector = value;
                OnHoveredSectorChanged();
            }
        }

        internal Sector SelectedSectorInternal
        {
            get { return _selectedSector; }
            set
            {
                _selectedSector = value;
                OnSelectedSectorChanged();

                _selectedSectorStation.Sector = _selectedSector;
                OnSelectedSectorStationChanged();
            }
        }

        public string SelectedSectorAllegiance
        {
            get { return _selectedSectorAllegiance; }
            set
            {
                if (Equals(_selectedSectorAllegiance, value))
                    return;
                _selectedSectorAllegiance = value;
                OnSelectedSectorAllegianceChanged();
            }
        }

        public string SelectedSectorInhabitants
        {
            get { return _selectedSectorInhabitants; }
            set
            {
                if (Equals(_selectedSectorInhabitants, value))
                    return;
                _selectedSectorInhabitants = value;
                OnSelectedSectorInhabitantsChanged();
            }
        }

        public Ship SelectedShip
        {
            get
            {
                return _selectedShipResolved ?? _selectedShip;
            }
            set
            {
                if (Equals(_selectedShip, value) && Equals(_selectedShipResolved, value))
                    return;
                _selectedShip = value;
                _selectedShipResolved = value;
                OnSelectedShipChanged();
            }
        }

        public ShipView SelectedShipInTaskForce
        {
            get
            {
                return _selectedShipInTaskForce;
            }
            set
            {
                if (Equals(_selectedShipInTaskForce, value))
                    return;

                _selectedShipInTaskForce = value;
                OnSelectedShipInTaskForceChanged();

                if ((_selectedShipInTaskForce == null) || !_selectedShipInTaskForce.IsOwned)
                    return;

                _selectedShipResolved = _selectedShipInTaskForce.Source;
                OnSelectedShipChanged();
            }
        }

        public IEnumerable<ShipView> SelectedShipsInTaskForce
        {
            get
            {
                Civilization localPlayer = AppContext.LocalPlayerEmpire.Civilization;
                if (_selectedShip != null && _selectedSector != null && DiplomacyHelper.IsScanBlocked(localPlayer, _selectedSector))
                    _selectedShipsInTaskForce = null; // Enumerable.Empty<ShipView>();

                return _selectedShipsInTaskForce ?? Enumerable.Empty<ShipView>();
            }
            set
            {

                if (Equals(_selectedShipInTaskForce, value))
                    return;

                _selectedShipsInTaskForce = value;
                OnSelectedShipsInTaskForceChanged();
            }
        }

        public FleetViewWrapper SelectedTaskForce
        {
            get
            {
                if (_selectedSector != null && _selectedTaskForce != null)
                {

                    if (_selectedTaskForce.View != null && _selectedTaskForce.View.Ships != null && _selectedTaskForce.View.Ships.FirstOrDefault().Source != null)
                    {
                        Civilization localPlayer = AppContext.LocalPlayerEmpire.Civilization;
                        var owner = _selectedTaskForce.View.Ships.FirstOrDefault().Source.Owner;
                        if (owner != localPlayer && DiplomacyHelper.IsScanBlocked(localPlayer, _selectedSector))
                        {
                            _selectedTaskForce = null;
                        }
                    }
                }
                return _selectedTaskForce;
            }
            set
            {
                if (Equals(_selectedTaskForce, value))
                    return;
                _selectedTaskForce = value;
                OnSelectedTaskForceChanged();
            }
        }

        public List<FleetViewWrapper> ISpyShips
        {
            get { return _iSpyShips; }
            set { _iSpyShips = value; }
        }

        public TradeRoute SelectedTradeRoute
        {
            get { return _selectedTradeRoute; }
            set
            {
                if (Equals(_selectedTradeRoute, value))
                    return;
                _selectedTradeRoute = value;
                OnSelectedTradeRouteChanged();
            }
        }

        public IEnumerable<FleetViewWrapper> TaskForces
        {
            get { return _taskForces; }
            set
            {
                if (Equals(_taskForces, value))
                    return;
                _taskForces = value;
                OnTaskForcesChanged();
            }
        }

        public IEnumerable<FleetViewWrapper> LocalPlayerTaskForces
        {
            get { return _localPlayerTaskForces; }
            set
            {
                if (Equals(_localPlayerTaskForces, value))
                    return;
                _localPlayerTaskForces = value;
                OnLocalPlayerTaskForcesChanged();
            }
        }

        public IEnumerable<FleetViewWrapper> VisibleTaskForces
        {
            get
            {
                if (_localPlayerTaskForces == null)
                    return _otherVisibleTaskForces;
                return _localPlayerTaskForces.Union(_otherVisibleTaskForces);
            }
            set
            {
                if (Equals(_otherVisibleTaskForces, value))
                    return;
                _otherVisibleTaskForces = value;
                OnVisibleTaskForcesChanged();
            }
        }

        public void GeneratePlayerTaskForces(Civilization playerCiv)
        {
            var mapData = AppContext.LocalPlayerEmpire.MapData;

            List<FleetViewWrapper> playerList = new List<FleetViewWrapper>();
            List<FleetViewWrapper> otherVisibleList = new List<FleetViewWrapper>();

            if (TaskForces != null)
            {
                int count = 0;
                foreach (FleetViewWrapper fleetView in TaskForces)
                {
                    if (fleetView.View.Source.Owner == playerCiv)
                    {
                        fleetView.InsigniaImage = GetInsigniaImage(playerCiv.InsigniaPath);
                        playerList.Add(fleetView);
                    }
                    else if (SelectedSector.Station != null && DiplomacyHelper.IsScanBlocked(playerCiv, fleetView.View.Source.Sector))
                    {
                        GameLog.Client.Intel.DebugFormat("local playerCiv ={0},. fleet Owner ={1}, counter ={2}, scanblock ={3}",
                            playerCiv, fleetView.View.Source.Owner, count, DiplomacyHelper.IsScanBlocked(playerCiv, fleetView.View.Source.Sector));

                        if (!DiplomacyHelper.AreAtWar(playerCiv, SelectedSector.Owner))
                        {
                            fleetView.IsUnScannable = true;
                            fleetView.InsigniaImage = GetInsigniaImage("Resources/Images/Insignias/_ScanBlock.png");
                            count++;
                            GameLog.Client.Intel.DebugFormat("IsUnScannable was True so got Insignia _ScanBlock & count++ ={0}", count);
                            _iSpyShips.Add(fleetView);
                        }
                        else fleetView.InsigniaImage = GetInsigniaImage(fleetView.View.Source.Owner.InsigniaPath);
                    }
                    else if (mapData.GetScanStrength(fleetView.View.Source.Location) > 0)
                    {
                        if (!DiplomacyHelper.IsContactMade(playerCiv, fleetView.View.Source.Owner))
                        {
                            fleetView.IsUnknown = true;
                            fleetView.InsigniaImage = GetInsigniaImage("Resources/Images/Insignias/__unknown.png");
                            count++;

                        }
                        else fleetView.InsigniaImage = GetInsigniaImage(fleetView.View.Source.Owner.InsigniaPath);
                    }

                    if (count <= 1)
                    {
                        otherVisibleList.Add(fleetView);
                        GameLog.Client.Intel.DebugFormat("otherVisibleList count ={0}", otherVisibleList.Count);
                    }
                }
            }

            LocalPlayerTaskForces = playerList;
            VisibleTaskForces = otherVisibleList;
        }

        public BitmapImage GetInsigniaImage(string insigniaPath)
        {
            Uri imageUri;
            var imagePath = insigniaPath.ToLowerInvariant();

            if (File.Exists(ResourceManager.GetResourcePath(insigniaPath)))
                imageUri = ResourceManager.GetResourceUri(insigniaPath);
            else
                imageUri = ResourceManager.GetResourceUri(@"Resources\Images\Insignias\__default.png");

            return ImageCache.Current.Get(imageUri);
        }

        public IEnumerable<TradeRoute> TradeRoutes
        {
            get { return _tradeRoutes; }
            set
            {
                if (Equals(_tradeRoutes, value))
                    return;
                _tradeRoutes = value;
                OnTradeRoutesChanged();
            }
        }
        #endregion

        #region Private Methods
        private void OnAvailableShipsChanged()
        {
            var handler = AvailableShipsChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnInputModeChanged()
        {
            var handler = InputModeChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnOverviewModeChanged()
        {
            var handler = OverviewModeChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedSectorAllegianceChanged()
        {
            var handler = SelectedSectorAllegianceChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedSectorChanged()
        {
            var handler = SelectedSectorChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnHoveredSectorChanged()
        {
            var handler = HoveredSectorChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedSectorInhabitantsChanged()
        {
            var handler = SelectedSectorInhabitantsChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedSectorStationChanged()
        {
            var handler = SelectedSectorStationChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedShipChanged()
        {
            var handler = SelectedShipChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedShipInTaskForceChanged()
        {
            var handler = SelectedShipInTaskForceChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedShipsInTaskForceChanged()
        {
            var handler = SelectedShipsInTaskForceChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedTaskForceChanged()
        {
            var handler = SelectedTaskForceChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnSelectedTradeRouteChanged()
        {
            var handler = SelectedTradeRouteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnTaskForcesChanged()
        {
            var handler = TaskForcesChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnLocalPlayerTaskForcesChanged()
        {
            var handler = LocalPlayerTaskForcesChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnVisibleTaskForcesChanged()
        {
            var handler = VisibleTaskForcesChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnTradeRoutesChanged()
        {
            var handler = TradeRoutesChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
    }
}
