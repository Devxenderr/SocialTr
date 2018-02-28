using System;
using System.Collections.Generic;

using SocialTrading.iOS.Cells;
using SocialTrading.Vipers.Tools.Interfaces.View;

using UIKit;
using Foundation;

namespace SocialTrading.iOS.Controllers.DataSources
{
    public class ToolsDataSource : UITableViewDataSource
    {
		private readonly List<string> _tools;
        private readonly IToolsStylesHolder _stylesHolder;

        public ToolsDataSource(List<string> tools, IToolsStylesHolder stylesHolder)
        {
            _tools = tools;
            _stylesHolder = stylesHolder;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var toolCell = (ToolViewCell)tableView.DequeueReusableCell(ToolViewCell.Key, indexPath);
			var curTool = _tools[indexPath.Row];
			toolCell.SetData(curTool);
            toolCell.SetThemes(_stylesHolder.UnselectedCellTheme, _stylesHolder.ToolNameTheme);

            return toolCell;			
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _tools.Count;
        }
    }
}
