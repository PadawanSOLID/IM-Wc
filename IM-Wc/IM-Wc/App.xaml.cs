using IM_Wc.Constants;
using IM_Wc.Models;
using IM_Wc.ViewModels;
using IM_Wc.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace IM_Wc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            LoadConfig();
        }
        //将上次登录的用户信息读到静态User属性
        void LoadConfig()
        {

        }
        public static User User { get; set; }
        protected override Window CreateShell()
        {
            var login = Container.Resolve<LoginView>().ShowDialog();
            if (login.Value)
            {
                return Container.Resolve<ShellWindow>();
            }
            else { Shutdown();return null; }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<CustomDialogWindow>();

            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ShellWindow, ShellViewModel>();

            containerRegistry.RegisterForNavigation<ChatsView,ChatsViewModel>(ContentPageKeys.Chats);
            containerRegistry.RegisterForNavigation<EmptyView>(ContentPageKeys.Empty);
            containerRegistry.RegisterForNavigation<ContactsView,ContactsViewModel>(ContentPageKeys.Contacts);
            containerRegistry.RegisterForNavigation<FavoritesView,FavoritesViewModel>(ContentPageKeys.Favorites);
            containerRegistry.RegisterForNavigation<NewFriendsView, NewFriendsViewModel>(ContentPageKeys.NewFriends);

            containerRegistry.RegisterForNavigation<ChatsListView, ChatsListViewModel>(ListPageKeys.ChatsList);
            containerRegistry.RegisterForNavigation<ContactsListView, ContactsListViewModel>(ListPageKeys.ContactsList);
            containerRegistry.RegisterForNavigation<FavoritesListView, FavoritesListViewModel>(ListPageKeys.FavoritesList);

            containerRegistry.RegisterDialog<ChatFilesView,ChatFilesViewModel>(DialogKeys.ChatFiles);
            containerRegistry.RegisterDialog<MomentsView,MomentsViewModel>(DialogKeys.Moments);
            containerRegistry.RegisterDialog<ChannelsView,ChannelsViewModel>(DialogKeys.Channels);
            containerRegistry.RegisterDialog<TopStoriesView,TopStoriesViewModel>(DialogKeys.TopStories);
            containerRegistry.RegisterDialog<SearchView,SearchViewModel>(DialogKeys.Search);

        }
    }

}
