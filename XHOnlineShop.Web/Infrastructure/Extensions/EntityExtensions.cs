using XHOnlineShop.Model.Models;
using XHOnlineShop.Web.Models;

namespace XHOnlineShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;
            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.Status = postCategoryViewModel.Status;
        }
        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.CategoryID = postViewModel.CategoryID;
            post.Image = postViewModel.Image;
            post.Description = postViewModel.Description;
            post.Content = postViewModel.Content;
            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.ViewCount = postViewModel.ViewCount;
            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }
        public static void UpdateProductCategory(this ProductCategory productCategoryCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategoryCategory.ID = productCategoryViewModel.ID;
            productCategoryCategory.Name = productCategoryViewModel.Name;
            productCategoryCategory.Alias = productCategoryViewModel.Alias;
            productCategoryCategory.Description = productCategoryViewModel.Description;
            productCategoryCategory.ParentID = productCategoryViewModel.ParentID;
            productCategoryCategory.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategoryCategory.Image = productCategoryViewModel.Image;
            productCategoryCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategoryCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategoryCategory.CreatedBy = productCategoryViewModel.CreatedBy;
            productCategoryCategory.UpdatedDate = productCategoryViewModel.UpdatedDate;
            productCategoryCategory.UpdatedBy = productCategoryViewModel.UpdatedBy;
            productCategoryCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategoryCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategoryCategory.Status = productCategoryViewModel.Status;
        }
    }
}