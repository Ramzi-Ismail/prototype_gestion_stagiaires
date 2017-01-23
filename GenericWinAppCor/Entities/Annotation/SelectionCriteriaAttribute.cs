using System;

namespace App.WinForm.Annotation
{
    public  class SelectionCriteriaAttribute : Attribute
    {
        public Type[] Criteria { set; get; }

        public SelectionCriteriaAttribute(params Type[] Criteria)
        {
            this.Criteria = Criteria;
        }
    }
}