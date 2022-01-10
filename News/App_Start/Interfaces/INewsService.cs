using News.ViewModels;
using System.Collections.Generic;

namespace News.App_Start.Interfaces
{
    public interface INewsService
    {
        void AddNews(NewsViewModel model);
        NewsViewModel GetNewsById(int id);
        void EditNews(NewsViewModel model);
        void RemoveNews(int id);
        IEnumerable<NewsViewModel> GetLastSixNews();
        List<NewsViewModel> GetNewNews(int? skipCount);
        IEnumerable<NewsViewModel> GetItemsPage(int? Count);
    }
}
