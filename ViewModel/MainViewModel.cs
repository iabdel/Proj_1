
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        items = new ObservableCollection<string>();
    }
    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [ICommand]
    void Add()
    {
        if(string.IsNullOrEmpty(Text))
            return;
        Items.Add(Text);
        Text = string.Empty;
    }
    [ICommand]
    void Delete(string s)
    {
        if(Items.Contains(s))
        {
            Items.Remove(s);
        }
    }
    [ICommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}
