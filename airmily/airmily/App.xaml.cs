using System;
using System.Collections.Generic;
using System.Diagnostics;
using airmily.Ext;
using airmily.Interfaces;
using airmily.Services.Auth;
using airmily.Services.Azure;
using airmily.Services.Interfaces;
using airmily.Services.Models;
using airmily.ViewModels;
using airmily.Views;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Unity;
using Xamarin.Forms;

namespace airmily
{
    public partial class App : PrismApplication
    {
		public readonly bool MockData = true;

	    public App(IPlatformInitializer initializer = null) : base(initializer)
	    {
		    //initializer?.RegisterTypes(Container);
	    }

	    protected override void OnInitialized()
        {
            InitializeComponent();
            
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None
            };
			
			if (MockData) Auth.ClearAuthentication();

			if (Auth.GetAuthentication() == null)
				NavigationService.NavigateAsync("LoginPage");
			else
				NavigationService.NavigateAsync("NavigationPage/CardsListPage", new NavigationParameters {["continue"] = true});
        }

		protected override void RegisterTypes()
        {
			Container.RegisterType<IAzure, MockAzure>();
			Container.RegisterType<IAuth, Auth>();

	        Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<CardsListPage>();
            Container.RegisterTypeForNavigation<TransactionsListPage>();
            Container.RegisterTypeForNavigation<ViewImagesPage>();
            Container.RegisterTypeForNavigation<CarouselImageGalleryPage>();
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory((view, type) =>
            {
                ParameterOverrides overrides = null;

                var page = view as Page;
                if (page != null)
                {
                    var navService = CreateNavigationService();
                    ((IPageAware) navService).Page = page;

                    overrides = new ParameterOverrides
                    {
                        {"navigationService", navService}
                    };
                }
                else
                {
                    overrides = new ParameterOverrides();

                    var nss = view as INavigationServiceExt;
                    if (nss != null)
                    {
                        var navService = CreateNavigationService();
                        overrides.Add("navigationService", navService);
                    }

                    var eas = view as IEventAggregatorExt;
                    if (eas != null)
                    {
                        var eventAggregator = Container.Resolve<IEventAggregator>();
                        overrides.Add("eventAggregator", eventAggregator);
                    }
                }

                return Container.Resolve(type, overrides);
            });
        }

	    public void OpenCardsTransactionPage(string cardID)
	    {
			if (!string.IsNullOrEmpty(cardID))
		   		NavigationService.NavigateAsync("CardsListPage", new NavigationParameters { ["gotocard"] = cardID });
		}
	}
}
