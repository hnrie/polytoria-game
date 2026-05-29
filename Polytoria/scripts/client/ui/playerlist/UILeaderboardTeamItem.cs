// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Godot;
using Polytoria.Datamodel;
using System.Collections.Generic;

namespace Polytoria.Client.UI.Playerlist;

public partial class UILeaderboardTeamItem : Control
{
	private readonly Dictionary<Stat, Label> _statToLabel = [];

	[Export] private Label _teamNameLabel = null!;
	[Export] private Control _statsBox = null!;

	public Team TargetTeam = null!;
	public UILeaderboard Leaderboard = null!;

	public override void _Ready()
	{
		_teamNameLabel.Text = TargetTeam.GetDisplayName();
		ApplyColor();
		TargetTeam.PropertyChanged.Connect(OnPropertyChanged);
	}

	public override void _ExitTree()
	{
		TargetTeam.PropertyChanged.Disconnect(OnPropertyChanged);
		base._ExitTree();
	}

	private void OnPropertyChanged(string _)
	{
		ApplyColor();
	}

	private void ApplyColor()
	{
		SelfModulate = TargetTeam.Color;
	}

	public void AddStat(Stat stat)
	{
		Label l = new()
		{
			CustomMinimumSize = new(100, 0),
			HorizontalAlignment = HorizontalAlignment.Center,
			TextOverrunBehavior = TextServer.OverrunBehavior.TrimEllipsis
		};
		_statsBox.AddChild(l);
		_statToLabel[stat] = l;
	}

}
