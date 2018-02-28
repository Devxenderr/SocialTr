﻿using System;
using System.Collections.Generic;

using UIKit;
using Foundation;

using SocialTrading.iOS.Cells;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.iOS.Controllers.DataSources
{
    public class MoreOptionsDataSourse : UITableViewDataSource
    {
        private readonly List<Tuple<Type, EItemsOptions>> _dataSource;
        private readonly UIViewController _controller;

        public MoreOptionsDataSourse(List<Tuple<Type, EItemsOptions>> dataSource, UIViewController controller)
		{
            _dataSource = dataSource;
            _controller = controller;
		}

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var typeCell = _dataSource[indexPath.Row].Item1;
            var dataCell = _dataSource[indexPath.Row].Item2;

            if (typeCell == typeof(IProfileCell))
            {
                var profileSell = (ProfileTableViewCell)tableView.DequeueReusableCell(ProfileTableViewCell.Key, indexPath);
                profileSell.SetData(dataCell);
                return profileSell;
            }
            else if (typeCell == typeof(IOptionCell))
            {
                var optionsSell = (OptionsTableViewCell)tableView.DequeueReusableCell(OptionsTableViewCell.Key, indexPath);
                optionsSell.SetViewController(_controller);
                optionsSell.SetData(dataCell);
                return optionsSell;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Wrong type of cell!");
            }
        }

      
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _dataSource.Count;
        }

    }
}
