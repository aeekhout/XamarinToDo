using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ToDo.App.Models
{
    public class ToDoItem : ContentView
    {
      [AutoIncrement, PrimaryKey]
      public int ID { get; set; }

      public string Name { get; set; }

      public String Description { get; set; }

    }
}