// Copyright (c) 2023 Files Community
// Licensed under the MIT License. See the LICENSE.

using Microsoft.UI.Xaml;

namespace Files.App.Data.Models
{
	public class ColumnsViewModel : ObservableObject
	{
		private ColumnViewModel iconColumn = new()
		{
			UserLength = new GridLength(24, GridUnitType.Pixel),
			IsResizeable = false,
		};
		[LiteDB.BsonIgnore]
		public ColumnViewModel IconColumn
		{
			get => iconColumn;
			set => SetProperty(ref iconColumn, value);
		}

		private ColumnViewModel _GitStatusColumn = new();
		public ColumnViewModel GitStatusColumn
		{
			get => _GitStatusColumn;
			set => SetProperty(ref _GitStatusColumn, value);
		}

		private ColumnViewModel _GitLastCommitDateColumn = new();
		public ColumnViewModel GitLastCommitDateColumn
		{
			get => _GitLastCommitDateColumn;
			set => SetProperty(ref _GitLastCommitDateColumn, value);
		}

		private ColumnViewModel _GitLastCommitMessageColumn = new();
		public ColumnViewModel GitLastCommitMessageColumn
		{
			get => _GitLastCommitMessageColumn;
			set => SetProperty(ref _GitLastCommitMessageColumn, value);
		}

		private ColumnViewModel _GitCommitAuthorColumn = new();
		public ColumnViewModel GitCommitAuthorColumn
		{
			get => _GitCommitAuthorColumn;
			set => SetProperty(ref _GitCommitAuthorColumn, value);
		}

		private ColumnViewModel _GitLastCommitShaColumn = new();
		public ColumnViewModel GitLastCommitShaColumn
		{
			get => _GitLastCommitShaColumn;
			set => SetProperty(ref _GitLastCommitShaColumn, value);
		}

		private ColumnViewModel tagColumn = new();
		public ColumnViewModel TagColumn
		{
			get => tagColumn;
			set => SetProperty(ref tagColumn, value);
		}

		private ColumnViewModel nameColumn = new()
		{
			NormalMaxLength = 1000d
		};
		public ColumnViewModel NameColumn
		{
			get => nameColumn;
			set => SetProperty(ref nameColumn, value);
		}

		private ColumnViewModel statusColumn = new()
		{
			UserLength = new GridLength(50),
			NormalMaxLength = 80,
		};
		public ColumnViewModel StatusColumn
		{
			get => statusColumn;
			set => SetProperty(ref statusColumn, value);
		}

		private ColumnViewModel dateModifiedColumn = new();
		public ColumnViewModel DateModifiedColumn
		{
			get => dateModifiedColumn;
			set => SetProperty(ref dateModifiedColumn, value);
		}

		private ColumnViewModel pathColumn = new()
		{
			NormalMaxLength = 500,
		};
		public ColumnViewModel PathColumn
		{
			get => pathColumn;
			set => SetProperty(ref pathColumn, value);
		}

		private ColumnViewModel originalPathColumn = new()
		{
			NormalMaxLength = 500,
		};
		public ColumnViewModel OriginalPathColumn
		{
			get => originalPathColumn;
			set => SetProperty(ref originalPathColumn, value);
		}

		private ColumnViewModel itemTypeColumn = new();
		public ColumnViewModel ItemTypeColumn
		{
			get => itemTypeColumn;
			set => SetProperty(ref itemTypeColumn, value);
		}

		private ColumnViewModel dateDeletedColumn = new();
		public ColumnViewModel DateDeletedColumn
		{
			get => dateDeletedColumn;
			set => SetProperty(ref dateDeletedColumn, value);
		}

		private ColumnViewModel dateCreatedColumn = new()
		{
			UserCollapsed = true
		};
		public ColumnViewModel DateCreatedColumn
		{
			get => dateCreatedColumn;
			set => SetProperty(ref dateCreatedColumn, value);
		}

		private ColumnViewModel sizeColumn = new();
		public ColumnViewModel SizeColumn
		{
			get => sizeColumn;
			set => SetProperty(ref sizeColumn, value);
		}

		[LiteDB.BsonIgnore]
		public double TotalWidth =>
			IconColumn.Length.Value +
			GitStatusColumn.Length.Value +
			GitLastCommitDateColumn.Length.Value +
			GitLastCommitMessageColumn.Length.Value +
			GitCommitAuthorColumn.Length.Value +
			GitLastCommitShaColumn.Length.Value +
			TagColumn.Length.Value +
			NameColumn.Length.Value +
			DateModifiedColumn.Length.Value +
			PathColumn.Length.Value +
			OriginalPathColumn.Length.Value +
			ItemTypeColumn.Length.Value +
			DateDeletedColumn.Length.Value +
			DateCreatedColumn.Length.Value +
			SizeColumn.Length.Value +
			StatusColumn.Length.Value;

		public void SetDesiredSize(double width)
		{
			if (TotalWidth > width || TotalWidth < width)
			{
				var proportion = width / TotalWidth;

				//SetColumnSizeProportionally(proportion);
			}
		}

		/// <summary>
		/// Multiplies every column's length by the given amount if it is within the size
		/// </summary>
		/// <param name="factor"></param>
		private void SetColumnSizeProportionally(double factor)
		{
			NameColumn.TryMultiplySize(factor);
			GitStatusColumn.TryMultiplySize(factor);
			GitLastCommitDateColumn.TryMultiplySize(factor);
			GitLastCommitMessageColumn.TryMultiplySize(factor);
			GitCommitAuthorColumn.TryMultiplySize(factor);
			GitLastCommitShaColumn.TryMultiplySize(factor);
			TagColumn.TryMultiplySize(factor);
			DateModifiedColumn.TryMultiplySize(factor);
			PathColumn.TryMultiplySize(factor);
			OriginalPathColumn.TryMultiplySize(factor);
			ItemTypeColumn.TryMultiplySize(factor);
			DateDeletedColumn.TryMultiplySize(factor);
			DateCreatedColumn.TryMultiplySize(factor);
			SizeColumn.TryMultiplySize(factor);
			StatusColumn.TryMultiplySize(factor);
		}

		public override bool Equals(object? obj)
		{
			if (obj is null)
				return false;

			if (obj == this)
				return true;

			if (obj is ColumnsViewModel model)
			{
				return
					model.DateCreatedColumn.Equals(DateCreatedColumn) &&
					model.DateDeletedColumn.Equals(DateDeletedColumn) &&
					model.DateModifiedColumn.Equals(DateModifiedColumn) &&
					model.ItemTypeColumn.Equals(ItemTypeColumn) &&
					model.NameColumn.Equals(NameColumn) &&
					model.PathColumn.Equals(PathColumn) &&
					model.OriginalPathColumn.Equals(OriginalPathColumn) &&
					model.SizeColumn.Equals(SizeColumn) &&
					model.StatusColumn.Equals(StatusColumn) &&
					model.TagColumn.Equals(TagColumn) &&
					model.GitStatusColumn.Equals(GitStatusColumn) &&
					model.GitLastCommitDateColumn.Equals(GitLastCommitDateColumn) &&
					model.GitLastCommitMessageColumn.Equals(GitLastCommitMessageColumn) &&
					model.GitCommitAuthorColumn.Equals(GitCommitAuthorColumn) &&
					model.GitLastCommitShaColumn.Equals(GitLastCommitShaColumn);
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			var hashCode = DateCreatedColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ DateDeletedColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ DateModifiedColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ ItemTypeColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ NameColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ PathColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ OriginalPathColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ SizeColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ StatusColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ TagColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ GitStatusColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ GitLastCommitDateColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ GitLastCommitMessageColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ GitCommitAuthorColumn.GetHashCode();
			hashCode = (hashCode * 397) ^ GitLastCommitShaColumn.GetHashCode();

			return hashCode;
		}
	}
}
