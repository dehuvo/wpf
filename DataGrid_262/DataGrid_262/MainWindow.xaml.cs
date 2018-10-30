using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DataGrid_262 {
  public class Skill {
    public int Years { get; set; }
    public string Name { get; set; }
  }

  public class Person {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public List<Skill> SkillList { get; set; }
  }

  public class Persons : ObservableCollection<Person> {
    public Persons() {
      Add(new Person {
        Id = 1,
        Name = "홍길동",
        Position = "Programmer",
        SkillList = new List<Skill>()
      });
      Add(new Person {
        Id = 2,
        Name = "정길동",
        Position = "Programmer",
        SkillList = new List<Skill>()
      });
    }
  }

  public partial class MainWindow : Window {
    private void Window_Loaded(object sender, RoutedEventArgs e) {
      Persons persons = new Persons();
      persons[0].SkillList.Add(new Skill { Years = 5, Name = "C++" });
      persons[0].SkillList.Add(new Skill { Years = 15, Name = "Visual Basic" });
      persons[1].SkillList.Add(new Skill { Years = 7, Name = "C#" });
      persons[1].SkillList.Add(new Skill { Years = 4, Name = "VB.NET" });
      dg.ItemsSource = persons;
    }

    private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (e.AddedItems[0] is Person) {
        dg1.ItemsSource = ((Person) e.AddedItems[0]).SkillList;
      }
    }
  }
}