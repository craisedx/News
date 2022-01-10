using AutoMapper;
using News.App_Start.Interfaces;
using News.Migrations;
using News.Models;
using News.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace News.App_Start.Services
{
    public class NewsService : INewsService
    {
        const int pageSize = 6;
        private readonly IMapper mapper;
        private readonly ApplicationContext db;
        public NewsService(ApplicationContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        public void AddNews(NewsViewModel model)
        {
            db.Items.Add(mapper.Map<Item>(model));
            db.SaveChanges();
        }

        public NewsViewModel GetNewsById(int id)
        {
            var item = db.Items.Where(x => x.Id == id).FirstOrDefault();

            return mapper.Map<NewsViewModel>(item);
        }

        public void EditNews(NewsViewModel model)
        {
            var item = db.Items.Where(x => x.Id == model.Id).FirstOrDefault();

            if(item != null)
            {
                item.Header = model.Header;
                item.Subtitle = model.Subtitle;
                item.Text = model.Text;
                item.Image = model.Image;
                db.SaveChanges();
            }
        }

        public void RemoveNews(int id)
        {
            var item = db.Items.Where(x => x.Id == id).FirstOrDefault();

            if(item != null)
            {
                db.Remove(item);
                db.SaveChanges();
            }
        }

        public IEnumerable<NewsViewModel> GetLastSixNews()
        {
            var items = Enumerable.Reverse(db.Items).Take(6).AsQueryable();

            return  mapper.Map<IEnumerable<NewsViewModel>>(items);
        }

        public List<NewsViewModel> GetNewNews(int? skipCount)
        {
            if (!skipCount.HasValue)
            {
                skipCount = 0;
            }

            var items = db.Items.Skip(skipCount.Value).
                Take(pageSize).ToList();

            return mapper.Map<List<NewsViewModel>>(items);
        }

        public IEnumerable<NewsViewModel> GetItemsPage(int? count)
        {
            if (count.HasValue)
            {
                var items = db.Items.Take(count.Value);

                return mapper.Map<IEnumerable<NewsViewModel>>(items);
            }

            var allitems = db.Items.AsQueryable();

            return mapper.Map<IEnumerable<NewsViewModel>>(allitems);
        }
    }
}
