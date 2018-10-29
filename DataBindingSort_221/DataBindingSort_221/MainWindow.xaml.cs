using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace DataBindingSort_221 {
  public partial class MainWindow : Window {
    public ListCollectionView collectionView;
    public Emp emp;

    public MainWindow() {
      InitializeComponent();
    }

    public void DCChange(object sender, DependencyPropertyChangedEventArgs args) {
      collectionView = (ListCollectionView) CollectionViewSource.GetDefaultView(rootElement.DataContext);
    }

    private void OnClick(object sender, RoutedEventArgs e) {
      var b = sender as Button;
      collectionView.SortDescriptions.Clear();
      switch (b.Name) {
        case "BtnEmpno":
          collectionView.SortDescriptions.Add(new
         SortDescription("Empno", ListSortDirection.Ascending));
          break;
        case "BtnEname":
          collectionView.SortDescriptions.Add(new
         SortDescription("Ename", ListSortDirection.Ascending));
          break;
        case "BtnJob":
          collectionView.SortDescriptions.Add(new
         SortDescription("Job", ListSortDirection.Ascending));
          break;
      }
    }

    private void OnMove(object sender, RoutedEventArgs e) {
      var b = sender as Button;
      switch (b.Name) {
        case "Previous":
          if (collectionView.MoveCurrentToPrevious())
            emp = collectionView.CurrentAddItem as Emp;
          else
            collectionView.MoveCurrentToFirst();
          break;
        case "Next":
          if (collectionView.MoveCurrentToNext())
            emp = collectionView.CurrentAddItem as Emp;
          else
            collectionView.MoveCurrentToLast();
          break;
      }
    }

    private void OnFilter(object sender, RoutedEventArgs e) {
      switch (collectionView.Filter) {
        case null: collectionView.Filter = IsManager; break;
        default: collectionView.Filter = null; break;
      }
    }

    private bool IsManager(object o) {
      return (o as Emp)?.Job == "Manager";
    }
  }
}