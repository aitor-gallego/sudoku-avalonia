using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace sudoku_avalonia;

public partial class MainWindow : Window
{
    private readonly List<int> _sudoku = [5,3,4,6,7,2,1,9,8,
                                          6,7,8,1,9,5,3,4,2,
                                          9,1,2,3,4,8,5,6,7,
                                          8,5,9,4,2,6,7,1,3,
                                          7,6,1,8,5,3,9,2,4,
                                          4,2,3,7,9,1,8,5,6,
                                          9,6,1,2,8,7,3,4,5,
                                          5,3,7,4,1,9,2,8,6,
                                          2,8,4,6,3,5,1,7,9];
    public MainWindow()
    {
        InitializeComponent();
        IntiSudoku();
    }

    //sudoku generator
    private void IntiSudoku()
    {
        List<int> randomSudoku = [];

        foreach (var t in _sudoku)
        {
            Random rnd = new();
            if (rnd.Next(0, 3) == 0) 
                randomSudoku.Add(t);
            else
                randomSudoku.Add(0);
        }
        
        var i = 0;
        foreach (var tBox in Main.GetVisualDescendants().OfType<TextBox>())
        {
            if (randomSudoku[i] == 0)
                tBox.Text = "";
            else
            {
                tBox.Text = randomSudoku[i].ToString();
                tBox.IsReadOnly = true;
                tBox.Focusable = false;
                tBox.Foreground = Brushes.DarkSlateBlue;
            }
            i++;
        }
    }

     //input control
    private void TextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox tb) return;
        if (!int.TryParse(tb.Text, out var nVal) || nVal == 0)
            tb.Text = "";
    }

    private void MenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}