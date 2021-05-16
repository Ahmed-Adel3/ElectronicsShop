using System.Collections.Generic;

namespace ElectronicsShop.Models
{
    public class GridViewModel<T>
    {
        public List<T> GridRows { get; set; }
        public int CurrentPageNumber { get; set; }
        public double TotalPagesNumber { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }

        public GridViewModel(List<T> gridRows, int currentPageNumber, bool isFirstPage, bool isLastPage, double totalPagesNumber)
        {
            GridRows = gridRows;
            CurrentPageNumber = currentPageNumber;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;
            TotalPagesNumber = totalPagesNumber;
        }
    }
}
