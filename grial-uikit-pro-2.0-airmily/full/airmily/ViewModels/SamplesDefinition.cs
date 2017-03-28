using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace airmily
{
	public static class SamplesDefinition
	{
		private static List<SampleCategory> _samplesCategoryList;
		private static Dictionary<string, SampleCategory> _samplesCategories;
		private static List<Sample> _allSamples;
		private static List<SampleGroup> _samplesGroupedByCategory;

		public static string[] _categoriesColors = {
			"#921243",
			"#B31250",
			"#CD195E",
			"#56329A",
			"#6A40B9",
			"#7C4ECD",
			"#525ABB",
			"#5F7DD4",
			"#7B96E5"
		};

		public static List<SampleCategory> SamplesCategoryList
		{
			get
			{
				if (_samplesCategoryList == null)
				{
					InitializeSamples();
				}

				return _samplesCategoryList;
			}
		}

		public static Dictionary<string, SampleCategory> SamplesCategories 
		{ 
			get
			{
				if (_samplesCategories == null) {
					InitializeSamples();
				}

				return _samplesCategories;
			}
		}

		public static List<Sample> AllSamples { 
			get
			{
				if (_allSamples == null) {
					InitializeSamples ();
				}
				return _allSamples;
			}
		}

		public static List<SampleGroup> SamplesGroupedByCategory 
		{ 
			get
			{
				if (_samplesGroupedByCategory == null) {
					InitializeSamples ();
				}

				return _samplesGroupedByCategory;
			}
		}

		internal static Dictionary<string, SampleCategory> CreateSamples()
		{
			var categories = new Dictionary<string, SampleCategory>();

			categories.Add(
				"SOCIAL",
				new SampleCategory
				{
					Name = "Social",
					BackgroundColor = Color.FromHex(_categoriesColors[0]),
					BackgroundImage = SampleData.DashboardImagesList[6],
					Icon = GrialShapesFont.Person,
					Badge = 2,
					SamplesList = new List<Sample> {
						new Sample("Document Timeline", typeof(DocumentTimelinePage), SampleData.DashboardImagesList[6], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Timeline", typeof(TimelinePage), SampleData.DashboardImagesList[6], GrialShapesFont.QueryBuilder, false, true),

						new Sample("User Profile", typeof(ProfilePage), SampleData.DashboardImagesList[6], GrialShapesFont.AccountCircle),
						new Sample("Social", typeof(SocialPage), SampleData.DashboardImagesList[6], GrialShapesFont.Group),
						new Sample("Social Variant", typeof(SocialVariantPage), SampleData.DashboardImagesList[6], GrialShapesFont.Group),

					}
				}
			);

			categories.Add(
				"ARTICLES",
				new SampleCategory
				{
					Name = "Articles",
					BackgroundColor = Color.FromHex(_categoriesColors[1]),
					BackgroundImage = SampleData.DashboardImagesList[4],
					Icon = GrialShapesFont.InsertFile,
					Badge = 2,
					SamplesList = new List<Sample> {
						new Sample("Articles Classic View", typeof(ArticlesClassicViewPage), SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile, false, true),
						new Sample("Front Page News", typeof(FrontPageNewsPage), SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile, false, true),

						new Sample("Article View", typeof(ArticleViewPage), SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),
						new Sample("Articles List", typeof(ArticlesListPage), SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),
						new Sample("Articles List Variant", typeof(ArticlesListVariantPage), SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),
						new Sample("Articles Feed", typeof(ArticlesFeedPage), SampleData.DashboardImagesList[4], GrialShapesFont.InsertFile),

					}
				}
			);

			categories.Add(
				"DASHBOARD",
				new SampleCategory
				{
					Name = "Dashboards",
					BackgroundColor = Color.FromHex(_categoriesColors[2]),
					BackgroundImage = SampleData.DashboardImagesList[3],
					Badge = 5,
					Icon = GrialShapesFont.Dashboard,
					SamplesList = new List<Sample> {
						new Sample("Grial Movies", typeof(DashboardMultipleScrollPage), SampleData.DashboardImagesList[3], GrialShapesFont.LocalMovies, false, true),
						new Sample("Movie Selection", typeof(MovieSelectionPage), SampleData.DashboardImagesList[3], GrialShapesFont.LocalMovies, false, true),
						new Sample("Dashboard Cards", typeof(DashboardCardsPage), SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false, true),
						new Sample("Multiple Tiles", typeof(DashboardMultipleTilesPage), SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false, true),
						new Sample("Scrollable Dashboards", typeof(DashboardScrollablePage), SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false, true),

						new Sample("Icons Dashboard", typeof(DashboardPage), SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard),
						new Sample("Flat Dashboard", typeof(DashboardFlatPage), SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard),
						new Sample("Images Dashboard", typeof(DashboardWithImagesPage), SampleData.DashboardImagesList[3], GrialShapesFont.Dashboard, false),

					}
				}
			);


			categories.Add(
				"NAVIGATION",
				new SampleCategory
				{
					Name = "Navigation",
					BackgroundColor = Color.FromHex(_categoriesColors[3]),
					BackgroundImage = SampleData.DashboardImagesList[2],
					Badge = 5,
					Icon = GrialShapesFont.Menu,
					SamplesList = new List<Sample> {
						new Sample("Card List", typeof(CardsListPage), SampleData.DashboardImagesList[2], GrialShapesFont.List, false, true),
						new Sample("Empty State", typeof(EmptyStatePage), SampleData.DashboardImagesList[2], GrialShapesFont.Hourglass, false, true),
						new Sample("Notifications", typeof(NotificationsPage), SampleData.DashboardImagesList[2], GrialShapesFont.Notifications, false, true),
						new Sample("Welcome Page", typeof (WelcomePage), SampleData.DashboardImagesList[2], GrialShapesFont.Place, true, true),

						new Sample("Categories List Flat", typeof(CategoriesListFlatPage), SampleData.DashboardImagesList[2], GrialShapesFont.List),
						new Sample("Image Categories", typeof(CategoriesListWithImagesPage), SampleData.DashboardImagesList[2], GrialShapesFont.List),
						new Sample("Icon Categories", typeof(CategoriesListWithIconsPage), SampleData.DashboardImagesList[2], GrialShapesFont.List),
						new Sample("Custom NavBar", typeof(CustomNavBarPage), SampleData.DashboardImagesList[2], GrialShapesFont.WebAsset),
						new Sample("Root Page", typeof(RootPage), SampleData.DashboardImagesList[2], GrialShapesFont.Menu, false),
					}
				}
			);

			categories.Add(
				"LOGINS",
				new SampleCategory
				{
					Name = "Logins",
					BackgroundColor = Color.FromHex(_categoriesColors[4]),
					BackgroundImage = SampleData.DashboardImagesList[5],
					Badge = 2,
					Icon = GrialShapesFont.Lock,
					SamplesList = new List<Sample> {
						new Sample("Simple Sign Up", typeof(SimpleSignUpPage), SampleData.DashboardImagesList[5], GrialShapesFont.CheckCircle, true, true),
						new Sample("Simple Login", typeof(SimpleLoginPage), SampleData.DashboardImagesList[5], GrialShapesFont.CheckCircle, true, true),

						new Sample("Login", typeof(LoginPage), SampleData.DashboardImagesList[5], GrialShapesFont.Lock, true),
						new Sample("Sign Up", typeof(SignUpPage), SampleData.DashboardImagesList[5], GrialShapesFont.CheckCircle, true),
						new Sample("Password Recovery", typeof(PasswordRecoveryPage), SampleData.DashboardImagesList[5], GrialShapesFont.SettingsRestore, true)
					}
				}
			);

			categories.Add(
				"ECOMMERCE",
				new SampleCategory
				{
					Name = "Ecommerce",
					BackgroundColor = Color.FromHex(_categoriesColors[5]),
					BackgroundImage = SampleData.DashboardImagesList[1],
					Badge = 3,
					Icon = GrialShapesFont.ShoppingCart,
					SamplesList = new List<Sample> {
						new Sample("Product FullScreen", typeof(ProductItemFullScreenPage), SampleData.DashboardImagesList[1], GrialShapesFont.CardGiftcard, false, true),
						new Sample("Products Catalog", typeof(ProductsCatalogPage), SampleData.DashboardImagesList[1], GrialShapesFont.CardGiftcard, false, true),
						new Sample("Product Order", typeof(ProductOrder), SampleData.DashboardImagesList[5], GrialShapesFont.CardGiftcard, false, true),

						new Sample("Products Grid", typeof(ProductsGridPage), SampleData.DashboardImagesList[1] , GrialShapesFont.Module),
						new Sample("Products Grid Variant", typeof(ProductsGridVariantPage), SampleData.DashboardImagesList[1] , GrialShapesFont.Module),
						new Sample("Product Item View", typeof(ProductItemViewPage), SampleData.DashboardImagesList[1], GrialShapesFont.CardGiftcard),
						new Sample("Products Carousel", typeof(ProductsCarouselPage), SampleData.DashboardImagesList[1], GrialShapesFont.CardGiftcard),

					}
				}
			);

			categories.Add(
				"WALKTROUGH",
				new SampleCategory
				{
					Name = "Walkthroughs",
					BackgroundColor = Color.FromHex(_categoriesColors[6]),
					BackgroundImage = SampleData.DashboardImagesList[7],
					Badge = 2,
					Icon = GrialShapesFont.Carousel,
					SamplesList = new List<Sample> {
						new Sample("Walkthrough", typeof(WalkthroughPage), SampleData.DashboardImagesList[7], GrialShapesFont.Carousel, true, true),
						//new Sample("Walkthrough Gradient", typeof(WalkthroughGradientPage), SampleData.DashboardImagesList[7], GrialShapesFont.Carousel, true, true),
						new Sample("Walkthrough Flat", typeof(WalkthroughFlatPage), SampleData.DashboardImagesList[7], GrialShapesFont.Carousel, true, true),

						new Sample("Walkthrough Variant", typeof(WalkthroughVariantPage), SampleData.DashboardImagesList[7], GrialShapesFont.Carousel, true)
					}
				}
			);

			categories.Add(
				"MESSAGES",
				new SampleCategory
				{
					Name = "Messages",
					BackgroundColor = Color.FromHex(_categoriesColors[7]),
					BackgroundImage = SampleData.DashboardImagesList[8],
					Badge = 2,
					Icon = GrialShapesFont.Email,
					SamplesList = new List<Sample> {
						new Sample("Chat Timeline", typeof( ChatTimelinePage ), SampleData.DashboardImagesList[2], GrialShapesFont.QueryBuilder, false, true),
						new Sample("Recent Chat List", typeof(RecentChatListPage), SampleData.DashboardImagesList[2], GrialShapesFont.QueryBuilder, false, true),

						new Sample("Messages", typeof(MessagesListPage), SampleData.DashboardImagesList[8], GrialShapesFont.Email),
						new Sample("Chat Messages List", typeof(ChatMessagesListPage), SampleData.DashboardImagesList[8], GrialShapesFont.Forum),

					}
				}
			);

			categories.Add(
				"THEME",
				new SampleCategory
				{
					Name = "Grial Theme",
					BackgroundColor = Color.FromHex(_categoriesColors[8]),
					BackgroundImage = SampleData.DashboardImagesList[0],
					Badge = 9,
					Icon = GrialShapesFont.ColorPalette,
					SamplesList = new List<Sample> {
						new Sample("Animations", typeof(AnimationsPage), SampleData.DashboardImagesList[0], GrialShapesFont.LogoLottie, false, true),
						new Sample("Tab Control", typeof(TabControlSamplePage), SampleData.DashboardImagesList[0], GrialShapesFont.LogoGrial, false, true),
						new Sample("Tabbed Page", typeof(TabsPage), SampleData.DashboardImagesList[0], GrialShapesFont.Tab, false, true),
						new Sample("Demo Settings", typeof(GrialDemoSettings), SampleData.DashboardImagesList[0], GrialShapesFont.Settings, false, true),

						new Sample("About", typeof(GenericAboutPage), SampleData.DashboardImagesList[0], GrialShapesFont.Help, false, true),
						new Sample("Custom Settings Page", typeof(CustomSettingsPage), SampleData.DashboardImagesList[0], GrialShapesFont.Settings, false, true),
						new Sample("Custom Activity Indicator", typeof(CustomActivityIndicatorPage), SampleData.DashboardImagesList[0], GrialShapesFont.Loop, false, true),
						new Sample("Responsive Helpers", typeof(ResponsiveHelpersPage), SampleData.DashboardImagesList[0], GrialShapesFont.TabletAndroid, false, true),
						new Sample("Grial Font Icons", typeof(IconsPage), SampleData.DashboardImagesList[0], GrialShapesFont.LogoGrial, false, true),

						new Sample("Native Controls", typeof(ThemePage), SampleData.DashboardImagesList[0], GrialShapesFont.ColorPalette),
						new Sample("Custom Renderers", typeof(CustomRenderersPage), SampleData.DashboardImagesList[0], GrialShapesFont.ColorPalette),
						new Sample("Grial Common Views", typeof(CommonViewsPage), SampleData.DashboardImagesList[0], GrialShapesFont.LogoGrial),
						new Sample("Settings Page", typeof(SettingsPage), SampleData.DashboardImagesList[0], GrialShapesFont.Settings),
						new Sample("WebView", typeof(WebViewPage), SampleData.DashboardImagesList[0], GrialShapesFont.Public),

					}
				}
			);

			return categories;
		}

		internal static void InitializeSamples()
		{
			_samplesCategories = CreateSamples();

			_samplesCategoryList = new List<SampleCategory> ();

			foreach (var sample in _samplesCategories.Values) {
				_samplesCategoryList.Add (sample);
			}

			_allSamples =  new List<Sample>();

			_samplesGroupedByCategory = new List<SampleGroup> ();

			foreach(var sampleCategory in SamplesCategories.Values){

				var sampleItem = new SampleGroup(sampleCategory.Name.ToUpper());

				foreach(var sample in sampleCategory.SamplesList){
					_allSamples.Add (sample);
					sampleItem.Add (sample);
				}

				_samplesGroupedByCategory.Add (sampleItem);
			}
		}

		private static void RootPageCustomNavigation(INavigation navigation){
			SampleCoordinator.RaisePresentMainMenuOnAppearance ();
			navigation.PopToRootAsync ();
		}
	}

	public class SampleGroup : List<Sample>
	{
		private readonly string _name;

		public SampleGroup(string name)
		{
			_name = name;
		}

		public string Name 
		{
			get
			{
				return _name;
			}
		}
	}
}
