using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace sudoku_avalonia;

public partial class MainWindow : Window
{
    List<int> _randomSudoku = [];
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
    }

     //input control
    private void TextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox tb) return;
        if (!int.TryParse(tb.Text, out var nVal) || nVal == 0)
            tb.Text = "";
    }

    //dificultad sudoku
    private void Facil_OnClick(object? sender, RoutedEventArgs e)
    {
        Reset_Sudoku();
        MessageLbl.Content = "NIVEL FÁCIL";
        ComprobarBtn.IsEnabled = true;        
        
        foreach (var t in _sudoku)
        {
            Random rnd = new();
            if (rnd.Next(0, 3) == 0)
                _randomSudoku.Add(0);
            else
                _randomSudoku.Add(t);
        }

        var i = 0;
        foreach (var tBox in Main.GetVisualDescendants().OfType<TextBox>())
        {
            if (_randomSudoku[i] == 0)
            {
                tBox.Text = "";
                tBox.IsReadOnly = false;
                tBox.Focusable = true;
                tBox.Foreground = Brushes.Black;
            }
            else
            {
                tBox.Text = _randomSudoku[i].ToString();
                tBox.IsReadOnly = true;
                tBox.Focusable = false;
                tBox.Foreground = Brushes.DarkSlateBlue;
            }
            i++;
        }
    }
    private void Medio_OnClick(object? sender, RoutedEventArgs e)
    {
        ComprobarBtn.IsEnabled = true;
        Reset_Sudoku();
        MessageLbl.Content = "NIVEL MEDIO";
        ComprobarBtn.IsEnabled = true;        

        foreach (var t in _sudoku)
        {
            Random rnd = new();
            if (rnd.Next(0, 2) == 0)
                _randomSudoku.Add(0);
            else
                _randomSudoku.Add(t);
        }

        var i = 0;
        foreach (var tBox in Main.GetVisualDescendants().OfType<TextBox>())
        {
            if (_randomSudoku[i] == 0)
            {
                tBox.Text = "";
                tBox.IsReadOnly = false;
                tBox.Focusable = true;
                tBox.Foreground = Brushes.Black;
            }
            else
            {
                tBox.Text = _randomSudoku[i].ToString();
                tBox.IsReadOnly = true;
                tBox.Focusable = false;
                tBox.Foreground = Brushes.DarkSlateBlue;
            }
            i++;
        }
    }
    private void Dificil_OnClick(object? sender, RoutedEventArgs e)
    {
        Reset_Sudoku();
        MessageLbl.Content = "NIVEL DIFÍCIL";
        ComprobarBtn.IsEnabled = true;        

        foreach (var t in _sudoku)
        {
            Random rnd = new();
            if (rnd.Next(0, 5) == 0)
                _randomSudoku.Add(t);
            else
                _randomSudoku.Add(0);
        }

        var i = 0;
        foreach (var tBox in Main.GetVisualDescendants().OfType<TextBox>())
        {
            if (_randomSudoku[i] == 0)
            {
                tBox.Text = "";
                tBox.IsReadOnly = false;
                tBox.Focusable = true;
                tBox.Foreground = Brushes.Black;
            }
            else
            {
                tBox.Text = _randomSudoku[i].ToString();
                tBox.IsReadOnly = true;
                tBox.Focusable = false;
                tBox.Foreground = Brushes.DarkSlateBlue;
            }
            i++;
        }
    }
    
    //comprobar
    private void Comprobar_OnClick(object? sender, RoutedEventArgs e)
    {
        var rec = 0;
        foreach (var tBox in Main.GetVisualDescendants().OfType<TextBox>())
        {
            if (tBox.Text != _sudoku[rec].ToString())
            {
                MessageBrd.Background = Brushes.DarkRed;
                MessageLbl.Content = "SUDOKU INCORRECTO";
                tBox.Foreground = Brushes.DarkRed;
                return;
            }
            else
            {
                if (!tBox.IsReadOnly)
                {
                    tBox.Foreground = Brushes.Green;
                    tBox.Focusable = false;
                    tBox.IsReadOnly = true;
                }
            }
            rec++;
        }
        MessageLbl.Content = "SUDOKU RESUELTO"; 
    }
    
    //reset sudoku
    private void Reset_Sudoku()
    {
        MessageLbl.Content = "SELECCIONE UNA DIFICULTAD";
        MessageBrd.Background = Brushes.DarkSlateBlue;
        _randomSudoku.Clear();
    }
}