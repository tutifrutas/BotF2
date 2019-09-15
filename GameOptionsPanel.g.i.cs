﻿#pragma checksum "..\..\GameOptionsPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B33E1B5B8FBD1291B2FC1696EF8258B7DDEEC4F3B2C7D5D8935B2633B36D4DBD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Supremacy.Buildings;
using Supremacy.Client;
using Supremacy.Client.Behaviors;
using Supremacy.Client.Commands;
using Supremacy.Client.Context;
using Supremacy.Client.Controls;
using Supremacy.Client.Data;
using Supremacy.Client.Dialogs;
using Supremacy.Client.DragDrop;
using Supremacy.Client.Events;
using Supremacy.Client.Markup;
using Supremacy.Client.Themes;
using Supremacy.Client.Views;
using Supremacy.Combat;
using Supremacy.Diplomacy;
using Supremacy.Economy;
using Supremacy.Encyclopedia;
using Supremacy.Entities;
using Supremacy.Game;
using Supremacy.Orbitals;
using Supremacy.Scripting;
using Supremacy.Tech;
using Supremacy.Text;
using Supremacy.Types;
using Supremacy.UI;
using Supremacy.Universe;
using Supremacy.Utility;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Supremacy.Client {
    
    
    /// <summary>
    /// GameOptionsPanel
    /// </summary>
    public partial class GameOptionsPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 204 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GalaxyImage;
        
        #line default
        #line hidden
        
        
        #line 314 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstFederationPlayable;
        
        #line default
        #line hidden
        
        
        #line 322 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstTerranEmpirePlayable;
        
        #line default
        #line hidden
        
        
        #line 330 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstRomulanPlayable;
        
        #line default
        #line hidden
        
        
        #line 338 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstKlingonPlayable;
        
        #line default
        #line hidden
        
        
        #line 346 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstCardassianPlayable;
        
        #line default
        #line hidden
        
        
        #line 354 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstDominionPlayable;
        
        #line default
        #line hidden
        
        
        #line 362 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstBorgPlayable;
        
        #line default
        #line hidden
        
        
        #line 373 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstGalaxyShape;
        
        #line default
        #line hidden
        
        
        #line 381 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstGalaxySize;
        
        #line default
        #line hidden
        
        
        #line 389 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstPlanetDensity;
        
        #line default
        #line hidden
        
        
        #line 397 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstStarDensity;
        
        #line default
        #line hidden
        
        
        #line 405 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstMinorRaces;
        
        #line default
        #line hidden
        
        
        #line 413 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstGalaxyCanon;
        
        #line default
        #line hidden
        
        
        #line 421 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstTechLevel;
        
        #line default
        #line hidden
        
        
        #line 442 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstFederationModifier;
        
        #line default
        #line hidden
        
        
        #line 450 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstTerranEmpireModifier;
        
        #line default
        #line hidden
        
        
        #line 458 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstRomulanModifier;
        
        #line default
        #line hidden
        
        
        #line 466 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstKlingonModifier;
        
        #line default
        #line hidden
        
        
        #line 474 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstCardassianModifier;
        
        #line default
        #line hidden
        
        
        #line 482 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstDominionModifier;
        
        #line default
        #line hidden
        
        
        #line 490 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstBorgModifier;
        
        #line default
        #line hidden
        
        
        #line 512 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstModifierRecurringBalancing;
        
        #line default
        #line hidden
        
        
        #line 534 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstGamePace;
        
        #line default
        #line hidden
        
        
        #line 556 "..\..\GameOptionsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lstTurnTimer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SupremacyClient;component/gameoptionspanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameOptionsPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GalaxyImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.lstFederationPlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.lstTerranEmpirePlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.lstRomulanPlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.lstKlingonPlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.lstCardassianPlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.lstDominionPlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.lstBorgPlayable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.lstGalaxyShape = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.lstGalaxySize = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.lstPlanetDensity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.lstStarDensity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.lstMinorRaces = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.lstGalaxyCanon = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.lstTechLevel = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 16:
            this.lstFederationModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            this.lstTerranEmpireModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 18:
            this.lstRomulanModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 19:
            this.lstKlingonModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 20:
            this.lstCardassianModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 21:
            this.lstDominionModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 22:
            this.lstBorgModifier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 23:
            this.lstModifierRecurringBalancing = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 24:
            this.lstGamePace = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 25:
            this.lstTurnTimer = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
