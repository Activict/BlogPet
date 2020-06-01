using MyBlog.BLL.Interfaces;
using System;

namespace MyBlog.Web.ViewModel
{
    public class PageCounter
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int BlogsOnPage { get; set; } = 3;
        public int Skip { get { return (Page - 1) * BlogsOnPage; } }
        public bool HasPreviewPage { get { return Page > 1 && Page <= Pages; } }
        public bool HasNextPage { get { return Page > 0 && Page < Pages; } }
        public PageCounter(IBlogService blogService)
        {
            if (Pages == 0)
            {
                var allBlogs = blogService.GetAll();
                Pages = (int)Math.Ceiling(allBlogs.Count / (double)BlogsOnPage);
            }
        }
        public void UpdatePagesCount(IBlogService blogService)
        {
            var allBlogs = blogService.GetAll();
            Pages = (int)Math.Ceiling(allBlogs.Count/(double)BlogsOnPage);
        }
        public void UpdatePage(int page)
        {
            Page = page > 0 && page <= Pages ? page : 1;
        }
    }
}
