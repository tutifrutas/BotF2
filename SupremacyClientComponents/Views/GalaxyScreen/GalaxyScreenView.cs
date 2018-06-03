// GalaxyScreenView.cs
//
// Copyright (c) 2009 Mike Strobel
//
// This source code is subject to the terms of the Microsoft Reciprocal License (Ms-RL).
// For details, see <http://www.opensource.org/licenses/ms-rl.html>.
//
// All other rights reserved.

using System.Windows;
using System.Windows.Input;

using Microsoft.Practices.Unity;

using Supremacy.Annotations;
using Supremacy.Client.Commands;

namespace Supremacy.Client.Views
{
    public class GalaxyScreenView : GameScreenView<GalaxyScreenPresentationModel>, IGalaxyScreenView
    {
        static GalaxyScreenView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(GalaxyScreenView),
                new FrameworkPropertyMetadata(typeof(GalaxyScreenView)));
        }

        public GalaxyScreenView([NotNull] IUnityContainer container)
            : base(container)
        {
            InputBindings.Add(
                new KeyBinding(
                    ClientCommands.EndTurn,
                    Key.Enter,
                    ModifierKeys.Control));

            InputBindings.Add(
                new KeyBinding(
                    ClientCommands.EscapeCommand,
                    Key.Escape,
                    ModifierKeys.None));

            InputBindings.Add(
                new KeyBinding(
                    GalaxyScreenCommands.MapZoomIn,
                    Key.OemPlus,
                    ModifierKeys.Control));

            InputBindings.Add(
                new KeyBinding(
                    GalaxyScreenCommands.MapZoomOut,
                    Key.OemMinus,
                    ModifierKeys.Control));

            InputBindings.Add(
                new KeyBinding(
                    GalaxyScreenCommands.MapZoomIn,
                    Key.Add,
                    ModifierKeys.Control));

            InputBindings.Add(
                new KeyBinding(
                    GalaxyScreenCommands.MapZoomOut,
                    Key.Subtract,
                    ModifierKeys.Control));

            InputBindings.Add(
                new KeyBinding(
                    DebugCommands.RevealMap,
                    Key.F12,
                    ModifierKeys.None));

            InputBindings.Add(
                new KeyBinding(
                    DebugCommands.CheatMenu,
                    Key.F11,
                    ModifierKeys.None));

            InputBindings.Add(
                new KeyBinding(
                    DebugCommands.GameInfoScreen,
                    Key.F9,
                    ModifierKeys.None));

            //this.InputBindings.Add(
            //    new KeyBinding(
            //                            DebugCommands.GameInfoScreen,
            //        //DebugCommands.ShowEconomyView,
            //        Key.E,
            //        ModifierKeys.None));

            //this.InputBindings.Add(
            //    new KeyBinding(
            //                            DebugCommands.GameInfoScreen,
            //        //DebugCommands.ShowMilitaryView,
            //        Key.M,
            //        ModifierKeys.None));

            CommandBindings.Add(
                new CommandBinding(
                    ClientCommands.EscapeCommand,
                    ExecuteEscapeCommand,
                    CanExecuteEscapeCommand));
        }

        private void CanExecuteEscapeCommand(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = ((Model.SelectedTaskForce != null) ||
                               (Model.SelectedTradeRoute != null) ||
                               (Model.InputMode == GalaxyScreenInputMode.RedeployShips));
        }

        private void ExecuteEscapeCommand(object sender, ExecutedRoutedEventArgs args)
        {
            if (Model.SelectedTaskForce != null)
            {
                Model.SelectedTaskForce = null;
                args.Handled = true;
            }
            else if (Model.SelectedTradeRoute != null)
            {
                Model.SelectedTradeRoute = null;
                args.Handled = true;
            }
            else if (Model.InputMode == GalaxyScreenInputMode.RedeployShips)
            {
                Model.InputMode = GalaxyScreenInputMode.Normal;
                args.Handled = true;
            }
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            if (Model.InputMode == GalaxyScreenInputMode.Normal)
            {
                /*
                 * If a task force or trade route is selected, and the user presses the
                 * right mouse button, we only want to cancel the selection--we don't want
                 * to display the pop-up menu in this case.
                 */
                if (Model.SelectedTaskForce != null)
                {
                    Model.SelectedTaskForce = null;
                    e.Handled = true;
                    CaptureMouse();
                    return;
                }

                if (Model.SelectedTradeRoute != null)
                {
                    Model.SelectedTradeRoute = null;
                    e.Handled = true;
                    CaptureMouse();
                    return;
                }
            }
            base.OnMouseRightButtonDown(e);
        }

        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                ReleaseMouseCapture();
                e.Handled = true;
                return;
            }
            base.OnMouseRightButtonUp(e);
        }
    }
}
