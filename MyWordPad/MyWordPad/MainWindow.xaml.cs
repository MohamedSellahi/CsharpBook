using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MyWordPad {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      SetF1CommandBinding();
    }

    protected void FileExit_Click(object sender, RoutedEventArgs args) {
      // Close this window.
      this.Close();
      
    }


    protected void ToolsSpellingHints_Click(object sender, RoutedEventArgs args) {
      string spellHints = string.Empty;

      // Try to get a spelling error at the current caret location 
      SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
      // if there are errors 
      if(error != null) {
        foreach (string ss in error.Suggestions) {
          spellHints += string.Format("{0}\n", ss);
        }
        // sow suggestion and expand the expender 
        lblSpellinghints.Content = spellHints;
        expenderSpelling.IsExpanded = true;
      }
      else {
        lblSpellinghints.Content = string.Empty;
        expenderSpelling.IsExpanded = false;
      }
      
    }


    protected void MouseEnterExitArea(object sender, RoutedEventArgs args) {
      statBarTxt.Text = "Exit application";
    }

    protected void MouseEnterToolsHintsArea(object sender, RoutedEventArgs args) {
      statBarTxt.Text = "Show Spelling Suggestions";
    }


    protected void MouseLeaveArea(object sender, RoutedEventArgs args) {
      statBarTxt.Text = "Ready";
    }


    private void SetF1CommandBinding() {
      //CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
      //helpBinding.CanExecute += HelpBinding_CanExecute;
      //helpBinding.Executed += HelpBinding_Executed;
      //CommandBindings.Add(helpBinding);
      
    }

    //private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
    //  // 
    //  MessageBox.Show("The help windows is not implemented yes!");
    //}

    //private void HelpBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
    //  // here we can set canExecute to false if we want to prevent the command from 
    //  // excecuting 
    //  // we can test a condition to test if the current context provides a Help System 
    //  e.CanExecute = true;
      
    //}


   

    private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e) {
      SaveFileDialog saveDlg = new SaveFileDialog();
      saveDlg.Filter = "Text Files |*.txt";
      // did we click ok button ? 
      if(true == saveDlg.ShowDialog()) {
        // Save data to the name file 
        File.WriteAllText(saveDlg.FileName, txtData.Text); 
      }
      
    }

    private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) {
      e.CanExecute = true;
    }

    private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) {
      e.CanExecute = true; 
    }

    private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e) {
      // Create an opend dialog file 
      OpenFileDialog openDlg = new OpenFileDialog();
      openDlg.Filter = "Text Files|*.txt";
      // ok cicked ?
      if(openDlg.ShowDialog() == true) {
        // laod all text of selected file 
        string dataFromfile = File.ReadAllText(openDlg.FileName);
        // show the string in the TextBox 
        txtData.Text = dataFromfile;
      }


    }

    private void HelpCmdExecuted(object sender, ExecutedRoutedEventArgs e) {
      MessageBox.Show("The help windows is not implemented yes!");
    }

    private void HelpCanExecute(object sender, CanExecuteRoutedEventArgs e) {
      e.CanExecute = true;
    }
  }
}
