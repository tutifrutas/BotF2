// ILobbyScreenView.cs
//
// Copyright (c) 2009 Mike Strobel
//
// This source code is subject to the terms of the Microsoft Reciprocal License (Ms-RL).
// For details, see <http://www.opensource.org/licenses/ms-rl.html>.
//
// All other rights reserved.

namespace Supremacy.Client.Views
{
    public interface ILobbyScreenPresenter : IGameScreenPresenter<object, ILobbyScreenView> { }

    public interface ILobbyScreenView : IGameScreenView<object> { }
}