﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Graphics;
using Android.Support.V4.App;
using Android.App;
using Android.Activities;

namespace Android
{
	[Activity (Theme="@style/AppTheme", Label = "@string/SearchActivityTitle",ParentActivity = typeof(MainPageActivity))]
	public class SearchActivity : AppCompatActivityBase
	{
		V7Toolbar _toolBar;

		SearchView _searchView;

		ViewGroup _searchLayout;

		ListView _listView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.SearchActivityLayout);

			GetViewReferences();

			SetupScreen();
		}

		void GetViewReferences ()
		{
			_searchView = FindViewById<SearchView> (Resource.Id.MainSearchView);

			_searchLayout = FindViewById<ViewGroup>(Resource.Id.MainSearchViewParent);

			_toolBar = FindViewById<V7Toolbar>(Resource.Id.MainToolbar);

			_listView = FindViewById<ListView>(Resource.Id.resultList);
		}

		public void SetupScreen()
		{
			SetSupportActionBar(_toolBar);

			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			_listView.Adapter = new SearchLocationAdapter(this);

			_searchLayout.Click += OnSearchLayoutSelected;

			_searchView.QueryTextSubmit += OnQueryTextSubmit;

			_searchView.SetIconifiedByDefault(false);

			_searchView.SetQueryHint(GetString(Resource.String.SearchPageSearchBarHint));

			PersonalizeSearchView();

		}

		void OnQueryTextSubmit (object sender, SearchView.QueryTextSubmitEventArgs e)
		{
			
		}

		void PersonalizeSearchView ()
		{
			var ll = (LinearLayout)_searchView.GetChildAt(0);  

			var ll2 = (LinearLayout)ll.GetChildAt(2);  

			var ll3 = (LinearLayout)ll2.GetChildAt(1);  

			var p = (EditText)ll3.GetChildAt(0);

			p.SetHintTextColor(Color.LightGray);
		}

		void OnSearchLayoutSelected(object sender, EventArgs e)
		{
			_searchView.RequestFocus();
		}
	}
}