using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TreeUtility;

namespace MasterDetail.Models
{
    public class Category : ITreeNode<Category>
    {
        public int Id { get; set; }
        private int? _parentCategoryId;

        [Display(Name = "Parent Category")]
        public int? ParentCategoryId
        {
            get { return _parentCategoryId; }
            set
            {
                if (Id == value)
                {
                    throw new InvalidOperationException("A category can not itself as its parent");
                }
                _parentCategoryId = value;
            }
        }

        [Required(ErrorMessage = "You must enter a category name.")]
        [StringLength(20,ErrorMessage = "Category name must be 20 character or shorter.")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public virtual Category Parent { get; set; }
        public IList<Category> Children { get; set; }
    }
}
